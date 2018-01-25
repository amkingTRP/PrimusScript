using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyRedPlanet.PrimusScript.Base
{
    class ConditionVarVarBase : Condition
    {
        protected int varA;
        protected int varB;

        public void SetVarA(int vA)
        {
            varA = vA;
        }
        public void SetVarB(int vB)
        {
            varB = vB;
        }
    }
}
