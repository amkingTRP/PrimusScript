﻿using PrimusJRPG.PrimusScript.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimusJRPG.PrimusScript.Parser
{
    abstract class PrimusScriptParser
    {
        public abstract EventManager ParseScriptFile(string filename);
    }

    
}
