using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimusJRPG.PrimusScript.Base
{
    class ConditionGreaterVar : ConditionVarVarBase
    {
        public override bool Execute(EventManager caller)
        {
            return (caller.GetInternalVariable(this.varA) > caller.GetInternalVariable(this.varB));
        }
    }

}
