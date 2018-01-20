using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimusJRPG.PrimusScript.Base
{
    class Condition
    {
        public virtual bool Execute(EventManager caller)
        {
            return true;
        }
    }
}
