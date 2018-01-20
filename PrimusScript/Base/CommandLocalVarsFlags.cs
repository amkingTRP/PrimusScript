using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimusJRPG.PrimusScript.Base
{
    class CommandSetLocalFlag : CommandBase1P
    {
        public CommandSetLocalFlag()
        {
            id = "SetLocalFlag";
        }

        // set global flag A to true
        public override bool Execute(EventManager caller)
        {
            caller.SetInternalFlag(A, true);
            Step(caller);
            return true;
        }
    }

    class CommandUnsetLocalFlag : CommandBase1P
    {
        public CommandUnsetLocalFlag()
        {
            id = "UnsetLocalFlag";
        }
        // set global flag A to true
        public override bool Execute(EventManager caller)
        {
            caller.SetInternalFlag(A, false);
            Step(caller);
            return true;
        }
    }

    class CommandSetVar : CommandBase2P
    {
        public CommandSetVar()
        {
            id = "SetVar";
        }
        // copy local var A into B
        public override bool Execute(EventManager caller)
        {
            caller.SetInternalVariable(B, caller.GetInternalVariable(A));
            Step(caller);
            return true;
        }
    }
    class CommandSetVal : CommandBase2P
    {
        public CommandSetVal()
        {
            id = "SetVal";
        }
        // copy value A into local var B
        public override bool Execute(EventManager caller)
        {
            caller.SetInternalVariable(B, A);
            Step(caller);
            return true;
        }
    }
}
