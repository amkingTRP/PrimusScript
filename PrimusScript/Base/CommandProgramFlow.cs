using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimusJRPG.PrimusScript.Base
{
    class CommandReturn : Command
    {
        public CommandReturn()
        {
            id = "Return";
        }

        public override bool Execute(EventManager caller)
        {
            caller.PopEvent(); // get out of this event
            return true;
        }
    }

    class CommandResumeOnFlagSet : CommandBase1P
    {
        public CommandResumeOnFlagSet()
        {
            id = "ResumeOnFlagSet";
        }

        public override bool Execute(EventManager caller)
        {
            if (!caller.GetInternalFlag(A))
                return false;

            Step(caller);
            return true;
        }
    }
    class CommandResumeOnGlobalFlagSet : CommandBase1P
    {
        public CommandResumeOnGlobalFlagSet()
        {
            id = "ResumeOnGlobalFlagSet";
        }

        public override bool Execute(EventManager caller)
        {
            if (!PrimusScriptEnvironment.IsGlobalFlagSet(A))
                return false;

            Step(caller);
            return true;
        }
    }
}
