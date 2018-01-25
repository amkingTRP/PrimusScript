using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyRedPlanet.PrimusScript.Base
{
    class PrimusScriptBuilder
    {
        public static CommandGetGlobalVar GetGlobalVar(int src, int dest)
        {
            CommandGetGlobalVar cmd = new CommandGetGlobalVar();
            cmd.SetA(src);
            cmd.SetB(src);

            return cmd;
        }

        public static CommandPutGlobalVar PutGlobalVar(int src, int dest)
        {
            CommandPutGlobalVar cmd = new CommandPutGlobalVar();
            cmd.SetA(src);
            cmd.SetB(src);

            return cmd;
        }

        public static CommandSetGlobalFlag SetGlobalFlag(int dest)
        {
            CommandSetGlobalFlag cmd = new CommandSetGlobalFlag();
            cmd.SetA(dest);
            return cmd;
        }

        public static CommandUnsetGlobalFlag UnsetGlobalFlag(int dest)
        {
            CommandUnsetGlobalFlag cmd = new CommandUnsetGlobalFlag();
            cmd.SetA(dest);
            return cmd;
        }

        public static CommandSetLocalFlag SetLocalFlag(int dest)
        {
            CommandSetLocalFlag cmd = new CommandSetLocalFlag();
            cmd.SetA(dest);
            return cmd;
        }

        public static CommandUnsetLocalFlag UnsetLocalFlag(int dest)
        {
            CommandUnsetLocalFlag cmd = new CommandUnsetLocalFlag();
            cmd.SetA(dest);
            return cmd;
        }

        public static CommandSetVar SetVar(int src, int dest)
        {
            CommandSetVar cmd = new CommandSetVar();
            cmd.SetA(src);
            cmd.SetB(dest);
            return cmd;
        }

        public static CommandSetVal SetVal(int val, int dest)
        {
            CommandSetVal cmd = new CommandSetVal();
            cmd.SetA(val);
            cmd.SetB(dest);
            return cmd;
        }

        public static CommandAddVar AddVar(int A, int B, int dest)
        {
            CommandAddVar cmd = new CommandAddVar();
            cmd.SetA(A);
            cmd.SetB(B);
            cmd.SetC(dest);
            return cmd;
        }
        public static CommandMinusVar MinusVar(int A, int B, int dest)
        {
            CommandMinusVar cmd = new CommandMinusVar();
            cmd.SetA(A);
            cmd.SetB(B);
            cmd.SetC(dest);
            return cmd;
        }
        public static CommandMultVar MultVar(int A, int B, int dest)
        {
            CommandMultVar cmd = new CommandMultVar();
            cmd.SetA(A);
            cmd.SetB(B);
            cmd.SetC(dest);
            return cmd;
        }
        public static CommandDivVar DivVar(int A, int B, int dest)
        {
            CommandDivVar cmd = new CommandDivVar();
            cmd.SetA(A);
            cmd.SetB(B);
            cmd.SetC(dest);
            return cmd;
        }

        public static CommandReturn Return()
        {
            CommandReturn cmd = new CommandReturn();
            return cmd;
        }

        public static CommandResumeOnFlagSet ResumeOnFlagSet(int flag)
        {
            CommandResumeOnFlagSet cmd = new CommandResumeOnFlagSet();
            cmd.SetA(flag);
            return cmd;
        }

        public static CommandResumeOnGlobalFlagSet ResumeOnGlobalFlagSet(int flag)
        {
            CommandResumeOnGlobalFlagSet cmd = new CommandResumeOnGlobalFlagSet();
            cmd.SetA(flag);
            return cmd;
        }


        public static ConditionAND AND(Condition A, Condition B)
        {
            ConditionAND cnd = new ConditionAND();
            cnd.SetA(A);
            cnd.SetB(B);
            return cnd;
        }
        public static ConditionOR OR(Condition A, Condition B)
        {
            ConditionOR cnd = new ConditionOR();
            cnd.SetA(A);
            cnd.SetB(B);
            return cnd;
        }
        public static ConditionNOT NOT(Condition A)
        {
            ConditionNOT cnd = new ConditionNOT();
            cnd.SetA(A);
            return cnd;
        }

        public static ConditionGreaterVal GreaterVal(int variable, int value)
        {
            ConditionGreaterVal cnd = new ConditionGreaterVal();
            cnd.SetVal(value);
            cnd.SetVarA(variable);

            return cnd;
        }
        public static ConditionLessVal LessVal(int variable, int value)
        {
            ConditionLessVal cnd = new ConditionLessVal();
            cnd.SetVal(value);
            cnd.SetVarA(variable);

            return cnd;
        }

        public static ConditionEqualsVal EqualsVal(int variable, int value)
        {
            ConditionEqualsVal cnd = new ConditionEqualsVal();
            cnd.SetVal(value);
            cnd.SetVarA(variable);

            return cnd;
        }

        public static ConditionGlobalGreaterVal GlobalGreaterVal(int variable, int value)
        {
            ConditionGlobalGreaterVal cnd = new ConditionGlobalGreaterVal();
            cnd.SetVal(value);
            cnd.SetVarA(variable);

            return cnd;
        }
        public static ConditionGlobalLessVal GlobalLessVal(int variable, int value)
        {
            ConditionGlobalLessVal cnd = new ConditionGlobalLessVal();
            cnd.SetVal(value);
            cnd.SetVarA(variable);

            return cnd;
        }

        public static ConditionGlobalEqualsVal GlobalEqualsVal(int variable, int value)
        {
            ConditionGlobalEqualsVal cnd = new ConditionGlobalEqualsVal();
            cnd.SetVal(value);
            cnd.SetVarA(variable);

            return cnd;
        }
        public static ConditionEqualsVar EqualsVar(int varA, int varB)
        {
            ConditionEqualsVar cnd = new ConditionEqualsVar();
            cnd.SetVarA(varA);
            cnd.SetVarB(varB);
            return cnd;
        }
        public static ConditionGreaterVar GreaterVar(int varA, int varB)
        {
            ConditionGreaterVar cnd = new ConditionGreaterVar();
            cnd.SetVarA(varA);
            cnd.SetVarB(varB);
            return cnd;
        }
        public static ConditionLessVar LessVar(int varA, int varB)
        {
            ConditionLessVar cnd = new ConditionLessVar();
            cnd.SetVarA(varA);
            cnd.SetVarB(varB);
            return cnd;
        }

        public static ConditionFlagSetGlobal FlagSetGlobal(int flag)
        {
            ConditionFlagSetGlobal cnd = new ConditionFlagSetGlobal();
            cnd.SetFlag(flag);
            return cnd;
        }

        public static ConditionFlagSetLocal FlagSetLocal(int flag)
        {
            ConditionFlagSetLocal cnd = new ConditionFlagSetLocal();
            cnd.SetFlag(flag);
            return cnd;
        }
    }
}
