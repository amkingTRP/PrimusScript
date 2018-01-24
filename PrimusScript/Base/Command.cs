using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimusJRPG.PrimusScript.Base
{
    class Command
    {
        public virtual void Step(EventManager caller)
        {
            //default behaviour
            caller.PopStack();
            if (next != null)
                caller.PushStack(next);
        }
        public virtual bool Execute(EventManager caller)
        {
            return true;
        }

        public void SetNext(Command nxt)
        {
            next = nxt;
        }

        protected Command next;
        public String id;
    }
}
