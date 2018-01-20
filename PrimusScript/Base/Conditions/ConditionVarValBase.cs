using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimusJRPG.PrimusScript.Base
{
    class ConditionVarValBase : Condition
    {
        protected int varA;
        protected int val;

        public void SetVarA(int vA)
        {
            varA = vA;
        }
        public void SetVal(int v)
        {
            val = v;
        }
    }
}
