using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyRedPlanet.PrimusScript.Base
{
    class ConditionLessVal : ConditionVarValBase
    {
        public override bool Execute(EventManager caller)
        {
            return (caller.GetInternalVariable(this.varA) < this.val);
        }
    }
}
