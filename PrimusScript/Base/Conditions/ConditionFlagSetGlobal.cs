using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimusJRPG.PrimusScript.Base
{
    class ConditionFlagSetGlobal : ConditionFlagSetBase
    {
        public override bool Execute(EventManager caller)
        {
            return PrimusScriptEnvironment.IsGlobalFlagSet(this.flag);
        }
    }
}
