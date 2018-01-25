using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TinyRedPlanet.PrimusScript.Base
{
    class ConditionGlobalEqualsVal : ConditionVarValBase
    {
        public override bool Execute(EventManager caller)
        {
            return (PrimusScriptEnvironment.GetGlobalVariable(this.varA) == this.val);
        }
    }
}