using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using WerewolfAPI.Api;
using WerewolfAPI.Model;
using System.Threading;
using Action = WerewolfAPI.Model.Action;
using WerewolfAPI.Client;

namespace WerewolfClient
{
    class WerewolfModel : Model
    {
        private AutoResetEvent _autoEvent;
        private PlayerApi _playerEP;
        private GameApi _gameEP;
        private ActionApi _actionEP;
        private RoleApi _roleEP;
        private ChatApi _chatEP;

        private List<Role> _roles = null;
        private List<Action> _actions = null;
        private Player _player = null;
        public Player Player { get => _player; }
        private Game _game = null;
        private Role _playerRole = null;
        private List<Action> _playerActions = null;
        private Game.PeriodEnum? _currentPeriod;
        private int? _currentDay;
        private int _currentTime;
        private List<Player> _players = null;
        public List<Player> Players { get => _players; }
        private List<Player> _prevPlayers = null;
        public List<Player> PrevPlayers { get => _prevPlayers; }

        public const string TRUE = "True";
        public const string FALSE = "False";
        private long? latestChatId = 0;


        public enum EventEnum
        {
            NOP = 1,
            SignUp = 2,
            SignIn = 3,
            JoinGame = 4,
            GameStarted = 5,
            GameStopped = 6,
            SwitchToDayTime = 7,
            SwitchToNightTime = 8,
            UpdateDay = 9,
            UpdateTime = 10,
            Vote = 11,
            Action = 12,
            YouShotDead = 13,
            OtherShotDead = 14,
            Alive = 15,
            Chat = 16,
            ChatMessage = 17,
        }
        public const string ROLE_SEER = "Seer";
        public const string ROLE_AURA_SEER = "Aura Seer";
        public const string ROLE_PRIEST = "Priest";
        public const string ROLE_DOCTOR = "Doctor";
        public const string ROLE_WEREWOLF = "Werewolf";
        public const string ROLE_WEREWOLF_SHAMAN = "Werewolf Sharman";
        public const string ROLE_ALPHA_WEREWOLF = "Alpha Werewolf";
        public const string ROLE_WEREWOLF_SEER = "Werewolf Seer";
        public const string ROLE_MEDIUM = "Medium";
        public const string ROLE_BODYGUARD = "Bodyguard";
        public const string ROLE_JAILER = "Jailer";
        public const string ROLE_FOOL = "Fool";
        public const string ROLE_HEAD_HUNTER = "Head Hunter";
        public const string ROLE_SERIAL_KILLER = "Serial Killer";


        public const string ROLE_GUNNER = "Gunner";

        public const string ACTION_DAY_VOTE = "Day Vote";
        public const string ACTION_HOLYWATER = "Throw holy-water";
        public const string ACTION_SHOOT = "Shoot";
        public const string ACTION_JAIL = "Jail";
        public const string ACTION_ENCHANT = "Enchant";
        public const string ACTION_NIGHT_VOTE = "Night Vote";
        public const string ACTION_GUARD = "Guard";
        public const string ACTION_HEAL = "Heal";
        public const string ACTION_KILL = "Kill";
        public const string ACTION_REVEAL = "Reveal";
        public const string ACTION_AURA = "Aura";
        public const string ACTION_REVIVE = "Revive";

        private EventEnum _event { get; set; }
        public EventEnum Event { get => _event; set => _event = value; }
        private Dictionary<string, string> _eventPayloads;
        public Dictionary<string, string> EventPayloads { get => _eventPayloads; set => _eventPayloads = value; }

        private Boolean _isPlaying = false;
        // default base path
        private const string BASE_PATH = "http://localhost:2343/werewolf/";
        private Action _dayVoteAction = null;
        private Action _nightVoteAction = null;
        private Action _playerAction = null;

        public WerewolfModel()
        {
            _eventPayloads = new Dictionary<string, string>();
            _autoEvent = new AutoResetEvent(false);
        }

        private void InitilizeModel(string basepath)
        {
            _playerEP = new PlayerApi(basepath);
            _playerEP.ExceptionFactory = null;
            _gameEP = new GameApi(basepath);
            _gameEP.ExceptionFactory = null;
            _actionEP = new ActionApi(basepath);
            _actionEP.ExceptionFactory = null;
            _roleEP = new RoleApi(basepath);
            _roleEP.ExceptionFactory = null;
            _chatEP = new ChatApi(basepath);
            _chatEP.ExceptionFactory = null;

            try
            {
                _roles = _roleEP.RoleGet();
                _actions = _actionEP.ActionGet();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //TODO: to do what?
            }
        }

        public void Update()
        {
            lock (this)
            {
                try
                {
                    _game = _gameEP.GetGameById(_game.Id);
                    _prevPlayers = _players;
                    _players = _game.Players;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
                if (!_isPlaying)
                {
                    if (_game.Status == Game.StatusEnum.Playing)
                    {
                        // game is tarted, switch to game mode
                        Console.WriteLine("Game #{0} is started, switch to game mode.", _game.Id);
                        _isPlaying = true;
                        _currentPeriod = _game.Period;
                        _currentTime = 0;
                        _currentDay = _game.Day;

                        if (_player.Session != null && _player.Session != "")
                        {
                            try
                            {
                                _game = _gameEP.GameSessionSessionIDGet(_player.Session);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                return;
                            }
                            foreach (Player player in _game.Players)
                            {
                                if (player.Id == _player.Id)
                                {
                                    //_player = player;
                                    _player.Role = player.Role;
                                    _playerRole = player.Role;
                                }
                            }
                            _event = EventEnum.GameStarted;
                            if (_playerRole != null)
                            {
                                try
                                {
                                    _playerActions = _actionEP.FindActionsByRoleId(_playerRole.Id);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    return;
                                }
                                _eventPayloads["Player.Role.Id"] = _playerRole.Id.ToString();
                                _eventPayloads["Player.Role.Name"] = _playerRole.Name;
                                foreach (Action action in _playerActions)
                                {
                                    if (action.Name == ACTION_DAY_VOTE)
                                    {
                                        _dayVoteAction = action;
                                    }
                                    else if (action.Name == ACTION_NIGHT_VOTE)
                                    {
                                        _nightVoteAction = action;
                                    }
                                    else
                                    {
                                        _playerAction = action;
                                    }
                                }
                            }
                            else
                            {
                                //TODO should show error, issue #13
                                _eventPayloads["Player.Role.Name"] = "";
                            }
                        }
                    }
                    NotifyAll();
                }
                else //_isPlaying
                {
                    if (_game.Status == Game.StatusEnum.Playing) // still playing
                    {
                        foreach (Player player in _players)
                        {
                            Player prevPlayer = _prevPlayers.Where(p => p.Id == player.Id).Single<Player>();
                            if (player.Status == Player.StatusEnum.Shotdead && prevPlayer.Status != Player.StatusEnum.Shotdead)
                            {
                                if (player.Id == Player.Id)
                                {
                                    _event = EventEnum.YouShotDead;
                                }
                                else
                                {
                                    _event = EventEnum.OtherShotDead;
                                    _eventPayloads["Game.Target.Id"] = player.Id.ToString();
                                    _eventPayloads["Game.Target.Name"] = player.Name;
                                }
                                NotifyAll();
                            }
                            if (player.Status == Player.StatusEnum.Alive && prevPlayer.Status != Player.StatusEnum.Alive)
                            {
                                _event = EventEnum.Alive;
                                if (player.Id != Player.Id)
                                {
                                    _eventPayloads["Game.Target.Id"] = player.Id.ToString();
                                    _eventPayloads["Game.Target.Name"] = player.Name;
                                }
                                NotifyAll();
                            }
                        }
                        _currentTime++;
                        if (_game.Period != _currentPeriod) // change period
                        {
                            if (_game.Period == Game.PeriodEnum.Day)
                            {
                                _event = EventEnum.SwitchToDayTime;
                                _eventPayloads["Game.Current.Period"] = "Day";
                                _eventPayloads["Game.Current.Day"] = _game.Day.ToString();
                                _currentTime = 0;
                                NotifyAll();
                            }
                            else if (_game.Period == Game.PeriodEnum.Night)
                            {
                                _event = EventEnum.SwitchToNightTime;
                                _eventPayloads["Game.Current.Period"] = "Night";
                                _eventPayloads["Game.Current.Day"] = _game.Day.ToString();
                                _currentTime = 0;
                                NotifyAll();
                            }
                            _currentPeriod = _game.Period;
                        }
                        else if (_game.Day != _currentDay) // Update Day
                        {
                            _event = EventEnum.UpdateDay;
                            _eventPayloads["Game.Current.Day"] = _game.Day.ToString();
                            _currentDay = _game.Day;
                            NotifyAll();
                        }
                        // We should update event tick as well.
                        _event = EventEnum.UpdateTime;
                        _eventPayloads["Game.Current.Time"] = _currentTime.ToString();
                        NotifyAll();
                    }
                    else
                    {
                        _event = EventEnum.GameStopped;
                        _eventPayloads["Game.Outcome"] = _game.Outcome.ToString();
                        NotifyAll();
                    }
                    try
                    {
                        //List<ChatMessage> messages = _chatEP.ChatSessionIDChatIDGet(_player.Session, latestChatId);
                        ApiResponse<List<ChatMessage>> localResponse = _chatEP.ChatSessionIDChatIDGetWithHttpInfo(_player.Session, latestChatId);
                        if (localResponse.StatusCode == 200)
                        {
                            List<ChatMessage> messages = localResponse.Data;
                            long? maxChatId = messages.Max<ChatMessage>(m => m.Id);
                            if (maxChatId != null && maxChatId >= latestChatId)
                            {
                                latestChatId = maxChatId + 1;
                            }
                            Console.WriteLine("Latest chat id is {0} status is {1}", latestChatId, localResponse.StatusCode);
                            StringBuilder sb = new StringBuilder();
                            foreach (ChatMessage message in messages)
                            {
                                // I hate this
                                _event = EventEnum.ChatMessage;
                                _eventPayloads["Success"] = TRUE;
                                _eventPayloads["Game.Chatter"] = _players.Where(p => p.Id == message.Playerid).Single().Name;
                                _eventPayloads["Game.ChatMessage"] = message.Message.ToString();
                                NotifyAll();
                            }
                        }
                        else
                        {
                            Console.WriteLine("No chat data because of " + localResponse.StatusCode);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }

                }
            }
        }

        public void JoinGame()
        {
            if (_player == null)
            {
                _event = EventEnum.JoinGame;
                _eventPayloads["Success"] = FALSE;
                _eventPayloads["Error"] = "Sign in first";
            }
            try
            {
                try
                {
                    _game = _gameEP.GameSessionSessionIDGet(_player.Session);
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    _game = null;
                }
                if (_game == null)
                {
                    // Not in game, join one
                    _game = _gameEP.GameSessionSessionIDPost(_player.Session);
                }
                Console.WriteLine("Join game #{0}", _game.Id);
                _event = EventEnum.JoinGame;
                _eventPayloads["Success"] = TRUE;
                _eventPayloads["Game.Id"] = _game.Id.ToString();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                _event = EventEnum.JoinGame;
                _eventPayloads["Success"] = FALSE;
                _eventPayloads["Error"] = ex.ToString();
            }
            NotifyAll();
        }
        public void SignIn(string server, string login, string password)
        {
            try
            {
                InitilizeModel(server);
                Player p = new Player(null, login, password, null, null, null, Player.StatusEnum.Offline);
                _player = _playerEP.LoginPlayer(p);
                Console.WriteLine(_player.Session);
                _event = EventEnum.SignIn;
                _eventPayloads["Success"] = TRUE;
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                _event = EventEnum.SignIn;
                _eventPayloads["Success"] = FALSE;
                _eventPayloads["Error"] = ex.ToString();
            }
            NotifyAll();
        }
        public void SignUp(string server, string login, string password)
        {
            try
            {
                PlayerApi playerEP = new PlayerApi(server);
                Player p = new Player(null, login, password, null, null, null, Player.StatusEnum.Offline);
                _player = playerEP.AddPlayer(p);

                Console.WriteLine(_player.Id);
                _event = EventEnum.SignIn;
                _eventPayloads["Success"] = TRUE;
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                _event = EventEnum.SignUp;
                _eventPayloads["Success"] = FALSE;
                _eventPayloads["Error"] = ex.ToString();
            }
            NotifyAll();
        }

        public void Vote(string target)
        {
            try
            {
                if (_currentPeriod == Game.PeriodEnum.Day)
                {
                    _gameEP.GameActionSessionIDActionIDTargetIDPost(_player.Session, _dayVoteAction.Id, int.Parse(target));
                }
                else
                {
                    _gameEP.GameActionSessionIDActionIDTargetIDPost(_player.Session, _nightVoteAction.Id, int.Parse(target));
                }
                _event = EventEnum.SignIn;
                _eventPayloads["Success"] = TRUE;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                _event = EventEnum.Vote;
                _eventPayloads["Success"] = FALSE;
                _eventPayloads["Error"] = ex.ToString();

            }
            NotifyAll();
        }

        internal void Action(string target)
        {
            try
            {
                _gameEP.GameActionSessionIDActionIDTargetIDPost(_player.Session, _playerAction.Id, int.Parse(target));
                _event = EventEnum.Action;
                _eventPayloads["Success"] = TRUE;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                _event = EventEnum.Action;
                _eventPayloads["Success"] = FALSE;
                _eventPayloads["Error"] = ex.ToString();

            }
            NotifyAll();
        }

        internal void Chat(string v)
        {
            try
            {
                ChatMessage message = new ChatMessage(null, _game.Id, _player.Id, v, null);
                //_chatEP.ChatSessionIDPost(_player.Session, message);
                ApiResponse<Object> localResponse =  _chatEP.ChatSessionIDPostWithHttpInfo(_player.Session, message);
                if (localResponse.StatusCode == 201)
                {
                    _event = EventEnum.Chat;
                    _eventPayloads["Success"] = TRUE;
                }
                else
                {
                    _event = EventEnum.Chat;
                    _eventPayloads["Success"] = FALSE;
                    _eventPayloads["Error"] = localResponse.StatusCode.ToString();
                    Console.WriteLine("Send chat failed {0} {1}", localResponse.StatusCode, localResponse.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                _event = EventEnum.Chat;
                _eventPayloads["Success"] = FALSE;
                _eventPayloads["Error"] = ex.ToString();
            }
            NotifyAll();
        }

        public new void NotifyAll()
        {
            base.NotifyAll();
            //reset event
            _event = EventEnum.NOP;
            _eventPayloads.Clear();
        }
    }
}
