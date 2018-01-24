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

        public void SetCondition(Condition cndtn)
        {
            condition = cndtn;
        }

        public void SetThen(Command cmd)
        {
            _then = cmd;
        }

        public void SetElse(Command cmd)
        {
            _else = cmd;
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

        public override void Print(int indent)
        {
            base.Print(indent);
            Console.WriteLine();
            for (int i = 0; i < indent; i++)
                Console.Write("\t");
            Console.Write(this.GetType().ToString());

            if (condition != null)
            {
                for (int i = 0; i < indent; i++)
                    Console.Write("\t");
                Console.WriteLine("-Condition:");
                condition.Print(indent + 1);
            }
            if (_then != null)
            {
                for (int i = 0; i < indent; i++)
                    Console.Write("\t");
                Console.WriteLine("-Then:");
                _then.Print(indent + 1);
            }
            if (_else != null)
            {
                for (int i = 0; i < indent; i++)
                    Console.Write("\t");
                Console.WriteLine("-Else:");
                _else.Print(indent + 1);
            }


            if (next!=null)
            {
                next.Print(indent);
            }
        }

    }

}
