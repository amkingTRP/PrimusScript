using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimusJRPG.PrimusScript.Base
{
    class ConditionAND : Condition
    {
        Condition A, B;
        public override bool Execute(EventManager caller)
        {
            return (A.Execute(caller) && B.Execute(caller));
        }

        public void SetA(Condition a)
        {
            A = a;
        }

        public void SetB(Condition b)
        {
            B = b;
        }

        public override void Print(int indent)
        {
            base.Print(indent);
            A.Print(indent + 1);
            B.Print(indent + 1);
        }
    }
}
