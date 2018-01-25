using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyRedPlanet.PrimusScript.Base
{
    class ConditionLessVar : ConditionVarVarBase
    {
         public override bool Execute(EventManager caller)
        {
            return (caller.GetInternalVariable(this.varA) < caller.GetInternalVariable(this.varB));
        }
    }
}
