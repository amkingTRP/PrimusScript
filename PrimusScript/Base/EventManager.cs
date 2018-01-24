using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimusJRPG.PrimusScript.Base
{
    class EventManager
    {
        List<Event> allEvents;
        LinkedList<Command> executionStack;
        string name;

        bool[] internalFlags;
        int[] internalVariables;

        public EventManager()
        {
            allEvents = new List<Event>();
            executionStack = new LinkedList<Command>();
            internalFlags = new bool[64];
            internalVariables = new int[64];
        }

        public void SetName(string n)
        {
            name = n;
        }

        public string GetName()
        {
            return name;
        }

        public void AddEvent(Event ev)
        {
            allEvents.Add(ev);
        }

        public void SetInternalFlag(int i, bool on)
        {
            internalFlags[i] = on;
        }

        public bool GetInternalFlag(int i)
        {
            return internalFlags[i];
        }
        public void SetInternalVariable(int i, int val)
        {
            internalVariables[i] = val;
        }

        public int GetInternalVariable(int i)
        {
            return internalVariables[i];
        }
        public int GetCurrentPriority()
        {
            int temp = 0;
            for (int i = executionStack.Count - 1; i >= 0; i--)
            {
                Command cmd = executionStack.ElementAt(i);
                if(cmd.id.Equals("EventStart"))
                {
                    temp = ((EventStartCommand)cmd).GetOwner().GetPriority();
                }
            }

            return temp;
        }

        public void PopEvent()
        {
            while(executionStack.Count>0)
            {
                Command cmd = executionStack.Last();
                PopStack();
                if (cmd.id.Equals("EventStart"))
                    return;
            }
        }

        public void CheckEvents()
        {
            // run through all events in order of priority and check their conditions
        }

        public void RunStack()
        {
            if (executionStack.Count == 0)
                return;
            do
            {
                Command cmd = executionStack.Last();
                bool rc = cmd.Execute(this); // execute will be responsible for step()
                if (rc == false)
                    return;
            }
            while (executionStack.Count > 0);
        }

        public void PopStack()
        {
            if (executionStack.Count > 0)
                executionStack.RemoveLast();
        }

        public void PushStack(Command cmd)
        {
            executionStack.AddLast(cmd);
        }
    }
}
