using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WerewolfClient
{
    public abstract class Command
    {
        public enum CommandEnum { };
        public virtual CommandEnum Action { get; set; }
        public Dictionary<string, string> Payloads { get; set; }
    }
    public class Controller
    {
        protected List<Model> mList;

        public Controller()
        {
            mList = new List<Model>();
        }

        public void AddModel(Model m)
        {
            mList.Add(m);
        }

        // virtual keyword allow the method to be overriden
        public virtual void ActionPerformed(Command cmd)
        {
            throw new NotImplementedException();
        }
    }
}
