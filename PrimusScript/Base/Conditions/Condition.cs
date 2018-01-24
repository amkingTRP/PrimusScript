using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimusJRPG.PrimusScript.Base
{
    class Condition
    {
        public virtual bool Execute(EventManager caller)
        {
            return true;
        }

        public virtual void Print(int indent)
        {
            Console.WriteLine();
            for (int i = 0; i < indent; i++)
                Console.Write("\t");
            Console.Write(this.GetType().ToString());
        }
    }
}
