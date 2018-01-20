using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimusJRPG.PrimusScript.Base
{
    class CommandGetGlobalVar : CommandBase2P
    {
        public CommandGetGlobalVar()
        {
            id = "GetGlobalVar";
        }
        // copy global var A into local var B
        public override bool Execute(EventManager caller)
        {
            caller.SetInternalVariable(B, PrimusScriptEnvironment.GetGlobalVariable(A));
            Step(caller);
            return true;
        }
    }

    class CommandPutGlobalVar : CommandBase2P
    {
        public CommandPutGlobalVar()
        {
            id = "PutGlobalVar";
        }
        // copy local var A into global var B
        public override bool Execute(EventManager caller)
        {
            PrimusScriptEnvironment.SetGlobalVariable(A, caller.GetInternalVariable(B));
            Step(caller);
            return true;
        }
    }

    class CommandSetGlobalFlag : CommandBase1P
    {
        public CommandSetGlobalFlag()
        {
            id = "SetGlobalFlag";
        }
        // set global flag A to true
        public override bool Execute(EventManager caller)
        {
            PrimusScriptEnvironment.SetGlobalFlag(A, true);
            Step(caller);
            return true;
        }
    }

    class CommandUnsetGlobalFlag : CommandBase1P
    {
        public CommandUnsetGlobalFlag()
        {
            id = "UnsetGlobalFlag";
        }
        // set global flag A to true
        public override bool Execute(EventManager caller)
        {
            PrimusScriptEnvironment.SetGlobalFlag(A, false);
            Step(caller);
            return true;
        }
    }

}
