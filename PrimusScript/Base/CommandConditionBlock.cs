using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimusJRPG.PrimusScript.Base
{
    class CommandConditionBlock : Command
    {
        Condition condition;
        Command _then, _else;

        public CommandConditionBlock()
        {
            id = "ConditionBlock";
        }

        public override bool Execute(EventManager caller)
        {
            Step(caller);
            if(condition==null || condition.Execute(caller))
            {
                if(_then!=null)
                {
                    caller.PushStack(_then);
                }
            }
            else
            {
                if (_else != null)
                {
                    caller.PushStack(_else);
                }

            }

            return true;
        }
    }
}
