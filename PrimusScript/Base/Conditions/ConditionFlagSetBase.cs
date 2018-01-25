using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyRedPlanet.PrimusScript.Base
{
    class ConditionFlagSetBase : Condition
    {
        protected int flag;
        public void SetFlag(int f)
        {
            flag = f;
        }
    }
}
