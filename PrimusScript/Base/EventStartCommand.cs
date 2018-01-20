using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimusJRPG.PrimusScript.Base
{
    class EventStartCommand : Command
    {
        Command command;
        bool triggered;
        Event owner;
        
        public EventStartCommand(Event ownr)
        {
            id = "EventStart";
            owner = ownr;
            triggered = false;
        }

        public Event GetOwner()
        {
            return owner;
        }

        public override bool Execute(EventManager caller)
        {
            if (!triggered)
            {
                if (command != null)
                    caller.PushStack(command);
                triggered = true;
            }
            else
                Step(caller);

            return true;
        }

        public override void Step(EventManager caller)
        {
            base.Step(caller);
        }
    }
}
