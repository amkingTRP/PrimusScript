using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyRedPlanet.PrimusScript.Base
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

        public virtual void Print(int indent)
        {
            Console.WriteLine();
            for (int i = 0; i < indent; i++)
                Console.Write("\t");
            Console.Write(this.GetType().ToString());
            if(next!=null)
            {
                next.Print(indent);
            }
        }

        protected Command next;
        public String id;
    }
}
