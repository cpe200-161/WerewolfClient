# WerewolfAPI.Api.GameApi

All URIs are relative to *https://project-ile.net:1038/v1*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GameActionSessionIDActionIDTargetIDPost**](GameApi.md#gameactionsessionidactionidtargetidpost) | **POST** /game/action/{sessionID}/{actionID}/{targetID} | Perform action on a game
[**GameGet**](GameApi.md#gameget) | **GET** /game | Get list of games
[**GameSessionSessionIDDelete**](GameApi.md#gamesessionsessioniddelete) | **DELETE** /game/session/{sessionID} | Leave a game
[**GameSessionSessionIDGet**](GameApi.md#gamesessionsessionidget) | **GET** /game/session/{sessionID} | Get game session
[**GameSessionSessionIDPost**](GameApi.md#gamesessionsessionidpost) | **POST** /game/session/{sessionID} | Join a game
[**GetGameById**](GameApi.md#getgamebyid) | **GET** /game/{gameId} | Find game by ID


<a name="gameactionsessionidactionidtargetidpost"></a>
# **GameActionSessionIDActionIDTargetIDPost**
> Game GameActionSessionIDActionIDTargetIDPost (string sessionID, long? actionID, long? targetID)

Perform action on a game

Perform action of a user on a game

### Example
```csharp
using System;
using System.Diagnostics;
using WerewolfAPI.Api;
using WerewolfAPI.Client;
using WerewolfAPI.Model;

namespace Example
{
    public class GameActionSessionIDActionIDTargetIDPostExample
    {
        public void main()
        {
            var apiInstance = new GameApi();
            var sessionID = sessionID_example;  // string | ID of player'session to perform action
            var actionID = 789;  // long? | ID of action to perform
            var targetID = 789;  // long? | ID of target of the action

            try
            {
                // Perform action on a game
                Game result = apiInstance.GameActionSessionIDActionIDTargetIDPost(sessionID, actionID, targetID);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling GameApi.GameActionSessionIDActionIDTargetIDPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **sessionID** | **string**| ID of player&#39;session to perform action | 
 **actionID** | **long?**| ID of action to perform | 
 **targetID** | **long?**| ID of target of the action | 

### Return type

[**Game**](Game.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="gameget"></a>
# **GameGet**
> List<Game> GameGet ()

Get list of games

### Example
```csharp
using System;
using System.Diagnostics;
using WerewolfAPI.Api;
using WerewolfAPI.Client;
using WerewolfAPI.Model;

namespace Example
{
    public class GameGetExample
    {
        public void main()
        {
            var apiInstance = new GameApi();

            try
            {
                // Get list of games
                List&lt;Game&gt; result = apiInstance.GameGet();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling GameApi.GameGet: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<Game>**](Game.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="gamesessionsessioniddelete"></a>
# **GameSessionSessionIDDelete**
> Game GameSessionSessionIDDelete (string sessionID)

Leave a game

Leave   game as a player

### Example
```csharp
using System;
using System.Diagnostics;
using WerewolfAPI.Api;
using WerewolfAPI.Client;
using WerewolfAPI.Model;

namespace Example
{
    public class GameSessionSessionIDDeleteExample
    {
        public void main()
        {
            var apiInstance = new GameApi();
            var sessionID = sessionID_example;  // string | ID of player'session to leave game

            try
            {
                // Leave a game
                Game result = apiInstance.GameSessionSessionIDDelete(sessionID);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling GameApi.GameSessionSessionIDDelete: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **sessionID** | **string**| ID of player&#39;session to leave game | 

### Return type

[**Game**](Game.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="gamesessionsessionidget"></a>
# **GameSessionSessionIDGet**
> Game GameSessionSessionIDGet (string sessionID)

Get game session

Get game session information

### Example
```csharp
using System;
using System.Diagnostics;
using WerewolfAPI.Api;
using WerewolfAPI.Client;
using WerewolfAPI.Model;

namespace Example
{
    public class GameSessionSessionIDGetExample
    {
        public void main()
        {
            var apiInstance = new GameApi();
            var sessionID = sessionID_example;  // string | ID of player'session to get game information

            try
            {
                // Get game session
                Game result = apiInstance.GameSessionSessionIDGet(sessionID);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling GameApi.GameSessionSessionIDGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **sessionID** | **string**| ID of player&#39;session to get game information | 

### Return type

[**Game**](Game.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="gamesessionsessionidpost"></a>
# **GameSessionSessionIDPost**
> Game GameSessionSessionIDPost (string sessionID)

Join a game

Join an available game as a player

### Example
```csharp
using System;
using System.Diagnostics;
using WerewolfAPI.Api;
using WerewolfAPI.Client;
using WerewolfAPI.Model;

namespace Example
{
    public class GameSessionSessionIDPostExample
    {
        public void main()
        {
            var apiInstance = new GameApi();
            var sessionID = sessionID_example;  // string | ID of player'session to join game

            try
            {
                // Join a game
                Game result = apiInstance.GameSessionSessionIDPost(sessionID);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling GameApi.GameSessionSessionIDPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **sessionID** | **string**| ID of player&#39;session to join game | 

### Return type

[**Game**](Game.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getgamebyid"></a>
# **GetGameById**
> Game GetGameById (long? gameId)

Find game by ID

Returns a single game

### Example
```csharp
using System;
using System.Diagnostics;
using WerewolfAPI.Api;
using WerewolfAPI.Client;
using WerewolfAPI.Model;

namespace Example
{
    public class GetGameByIdExample
    {
        public void main()
        {
            var apiInstance = new GameApi();
            var gameId = 789;  // long? | ID of game to return

            try
            {
                // Find game by ID
                Game result = apiInstance.GetGameById(gameId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling GameApi.GetGameById: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **gameId** | **long?**| ID of game to return | 

### Return type

[**Game**](Game.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

