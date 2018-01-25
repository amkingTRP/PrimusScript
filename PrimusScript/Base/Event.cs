using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyRedPlanet.PrimusScript.Base
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

        public bool Triggered(EventManager caller)
        {
            if (trigger == null) // if no conditions specified then it would always trigger
                return true;
            return (trigger.Execute(caller));
            //return false;
        }

        public void Trigger(EventManager caller)
        {
            EventStartCommand esc = new EventStartCommand(this);
            esc.SetNext(command);
            caller.PushStack(esc);
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

        public void Print()
        {
            Console.WriteLine("Priority: " + priority);
            Console.WriteLine("Trigger: ");
            trigger.Print(1);
            Console.WriteLine();
            Console.WriteLine("Commands: ");
            GetFirstCommand().Print(1);
        }
    }
}
