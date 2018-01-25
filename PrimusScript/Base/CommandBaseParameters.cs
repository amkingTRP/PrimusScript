using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyRedPlanet.PrimusScript.Base
{
    class CommandBase1P : Command
    {
        protected int A;
        public void SetA(int a)
        {
            A = a;
        }
    }
    class CommandBase2P : CommandBase1P
    {
        protected int B;
        public void SetB(int b)
        {
            B = b;
        }
    }
    class CommandBase3P : CommandBase2P
    {
        protected int C;
        public void SetC(int c)
        {
            C = c;
        }
    }
    class CommandBase4P : CommandBase3P
    {
        protected int D;
        public void SetD(int d)
        {
            D = d;
        }
    }
}
