using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyRedPlanet.PrimusScript.Base
{
    class ConditionNOT : Condition
    {
        Condition A;
        public override bool Execute(EventManager caller)
        {
            return (!A.Execute(caller));
        }

        public void SetA(Condition a)
        {
            A = a;
        }
        public override void Print(int indent)
        {
            base.Print(indent);
            A.Print(indent + 1);
        }


    }
}
