using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimusJRPG.PrimusScript.Base
{
    class Event
    {
        Condition trigger;
        int priority;
        Command command;

        public Condition GetTrigger()
        {
            return trigger;
        }

        public void SetTrigger(Condition trggr)
        {
            trigger = trggr;
        }

        public bool Triggered()
        {
            return false;
        }

        public void Trigger(EventManager caller)
        {
            EventStartCommand esc = new EventStartCommand(this);
            esc.
        }

        public int GetPriority()
        {
            return priority;

        }

        public void SetPriority(int prty)
        {
            priority = prty;
        }

        public Command GetFirstCommand()
        {
            return command;
        }

        public void SetFirstCommand(Command cmd)
        {
            command = cmd;
        }
    }
}
