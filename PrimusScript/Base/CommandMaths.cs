using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimusJRPG.PrimusScript.Base
{
    class CommandAddVar : CommandBase3P
    {
        public CommandAddVar()
        {
            id = "AddVar";
        }
        // add local vars A & B and store in C
        public override bool Execute(EventManager caller)
        {
            int temp = caller.GetInternalVariable(A) + caller.GetInternalVariable(B);
            caller.SetInternalVariable(C, temp);
            Step(caller);
            return true;
        }
    }
    class CommandMinusVar : CommandBase3P
    {
        public CommandMinusVar()
        {
            id = "MinusVar";
        }
        // C = A-B
        public override bool Execute(EventManager caller)
        {
            int temp = caller.GetInternalVariable(A) - caller.GetInternalVariable(B);
            caller.SetInternalVariable(C, temp);
            Step(caller);
            return true;
        }
    }
    class CommandMultVar : CommandBase3P
    {
        public CommandMultVar()
        {
            id = "MultVar";
        }
        //C = A x B
        public override bool Execute(EventManager caller)
        {
            int temp = caller.GetInternalVariable(A) * caller.GetInternalVariable(B);
            caller.SetInternalVariable(C, temp);
            Step(caller);
            return true;
        }
    }
    class CommandDivVar : CommandBase3P
    {
        public CommandDivVar()
        {
            id = "DivVar";
        }
        // C = A / B
        public override bool Execute(EventManager caller)
        {
            int temp = caller.GetInternalVariable(A) / caller.GetInternalVariable(B);
            caller.SetInternalVariable(C, temp);
            Step(caller);
            return true;
        }
    }
}
