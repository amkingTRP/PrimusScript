using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyRedPlanet.PrimusScript.Base
{
    class ConditionFlagSetLocal : ConditionFlagSetBase
    {
        public override bool Execute(EventManager caller)
        {
            return caller.GetInternalFlag(this.flag);
        }
    }
}
