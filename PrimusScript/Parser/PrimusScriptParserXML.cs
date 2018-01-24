using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimusJRPG.PrimusScript.Base;
using System.Xml;

namespace PrimusJRPG.PrimusScript.Parser
{
    class PrimusScriptParserXML : PrimusScriptParser
    {
        Dictionary<string, int> aliasMap;
        public List<string> errorLog;
        XmlDocument xmlDoc;
        public bool errors;

        public PrimusScriptParserXML()
        {
            aliasMap = new Dictionary<string, int>();
            xmlDoc = new XmlDocument();
            errorLog = new List<string>();
            errors = false;
        }

        public void LogError(string error)
        {
            errorLog.Add(error);
            errors = true;
        }

        public virtual EventManager CreateEventManager()
        {
            return new EventManager();
        }
        public virtual Event CreateEvent()
        {
            return new Event();
        }

        public override EventManager ParseScriptFile(string filename)
        {
            try {
                xmlDoc.Load(filename);
            }
            catch(Exception e)
            {
                LogError("Error with loading xml doc " + filename + " : " + e.ToString());
                return null;
            }

            EventManager em = CreateEventManager();
            XmlNode node = xmlDoc.SelectSingleNode("primusscript");

            if(node==null)
            {
                LogError("Xml Doc doesn't start with PrimusScript node: " + xmlDoc.Name.ToLower());
                return null;
            }

            // put some checking around this
            em.SetName(node.Attributes["name"].Value);

            XmlNode tempNode = node.FirstChild;
            while(tempNode!=null)
            {
                switch(tempNode.Name.ToLower())
                {
                    case "alias":
                        int value = GetAttribute(tempNode, "value");
                        string alias = tempNode.Attributes["word"].Value;
                        AddAlias(alias, value);
                        break;
                    case "event":
                        Event ev = ParseEvent(tempNode);
                        em.AddEvent(ev);
                        break;

                    default:
                        ExtendedParsing(em, tempNode);
                        break;
                }
                tempNode = tempNode.NextSibling;
            }
            return em;
        }

        public virtual Event ParseEvent(XmlNode node)
        {
            if (node == null)
                return null;
            Event ev = CreateEvent();
            int priority = GetAttribute(node, "priority");
            ev.SetPriority(priority);
            XmlNode tempNode = node.FirstChild;

            while(tempNode!=null)
            {
                switch (tempNode.Name.ToLower())
                {
                    case "trigger":
                        Condition cdn = ParseCondition(tempNode.FirstChild);
                        ev.SetTrigger(cdn);
                        break;
                    case "commands":
                        Command cmd = ParseCommand(tempNode.FirstChild);
                        ev.SetFirstCommand(cmd);
                        break;
                    default:
                        ExtendedEventParsing(ev, tempNode);
                        break;
                }

                tempNode = tempNode.NextSibling;

            }
            return ev;
        }
        public virtual void ExtendedEventParsing(Event ev, XmlNode node)
        {
            if (node == null)
                return;

        }

        public void AddAlias(string alias, int value)
        {
            aliasMap.Add(alias, value);
        }

        public virtual void ExtendedParsing(EventManager em, XmlNode node)
        {
            if (node == null)
                return;

        }

        public int GetAttribute(XmlNode node, string attribute)
        {
            string value = "";
            try
            {
                value = node.Attributes[attribute].Value;
            }
            catch (Exception)
            {
                LogError("Attribute " + attribute + " not found in " + node.Name);
                return 0;
            }

            try
            {
                int val = Int32.Parse(value);
                return val;
            }
            catch(Exception)
            {
                if (aliasMap.ContainsKey(value))
                    return aliasMap[value];

                LogError("Unknown value " + value + " found for attribute " + attribute + " in " + node.ToString());
            }

            return 0;

        }

        public virtual Condition ParseExtendedCondition(XmlNode node)
        {
            return null;
        }
        public virtual Command ParseExtendedCommand(XmlNode node)
        {
            return null;
        }

        public Condition ParseCondition(XmlNode node)
        {
            if (node == null)
                return null;
            Condition cdn = null;
            int src, dest, val;
            Condition cA, cB;
            XmlNode A, B;
            switch (node.Name.ToLower())
            {
                case "and":
                    A = node.FirstChild;
                    if(A!=null)
                    {
                        B = A.NextSibling;
                        if(B!=null)
                        {
                            cA = ParseCondition(A);
                            cB = ParseCondition(B);
                            cdn = PrimusScriptBuilder.AND(cA, cB);
                        }
                    }
                    break;
                case "or":
                    A = node.FirstChild;
                    if (A != null)
                    {
                        B = A.NextSibling;
                        if (B != null)
                        {
                            cA = ParseCondition(A);
                            cB = ParseCondition(B);
                            cdn = PrimusScriptBuilder.OR(cA, cB);
                        }
                    }
                    break;
                case "not":
                    A = node.FirstChild;
                    if (A != null)
                    {
                        cA = ParseCondition(A);
                        cdn = PrimusScriptBuilder.NOT(cA);
                    }
                    break;
                case "greaterval":
                    src = GetAttribute(node, "A");
                    val = GetAttribute(node, "val");
                    cdn = PrimusScriptBuilder.GreaterVal(src, val);                    
                    break;
                case "greatervar":
                    src = GetAttribute(node, "A");
                    dest = GetAttribute(node, "B");
                    cdn = PrimusScriptBuilder.GreaterVar(src, dest);
                    break;
                case "lessval":
                    src = GetAttribute(node, "A");
                    val = GetAttribute(node, "val");
                    cdn = PrimusScriptBuilder.LessVal(src, val);
                    break;
                case "lessvar":
                    src = GetAttribute(node, "A");
                    dest = GetAttribute(node, "B");
                    cdn = PrimusScriptBuilder.LessVar(src, dest);
                    break;
                case "equalsvar":
                    src = GetAttribute(node, "A");
                    val = GetAttribute(node, "B");
                    cdn = PrimusScriptBuilder.EqualsVar(src, val);
                    break;
                case "equalsval":
                    src = GetAttribute(node, "A");
                    val = GetAttribute(node, "val");
                    cdn = PrimusScriptBuilder.EqualsVal(src, val);
                    break;
                case "localflagset":
                    src = GetAttribute(node, "flag");
                    cdn = PrimusScriptBuilder.FlagSetLocal(src);
                    break;
                case "globalflagset":
                    src = GetAttribute(node, "flag");
                    cdn = PrimusScriptBuilder.FlagSetLocal(src);
                    break;

                default:
                    cdn = ParseExtendedCondition(node);
                    break;
            }

            return cdn;
        }

        public Command ParseConditionBlock(XmlNode node)
        {
            CommandConditionBlock cmd = new CommandConditionBlock();
            Condition cnd = null;
            Command thn = null;
            Command els = null;

            XmlNode temp = node.FirstChild;
            while(temp!=null)
            {
                switch (temp.Name.ToLower())
                {
                    case "condition":
                        cnd = ParseCondition(temp.FirstChild);
                        break;

                    case "then":
                        thn = ParseCommand(temp.FirstChild);
                        break;

                    case "else":
                        els = ParseCommand(temp.FirstChild);
                        break;
                }
                temp = temp.NextSibling;
            }
            cmd.SetCondition(cnd);
            cmd.SetElse(els);
            cmd.SetThen(thn);

            return cmd;
        }

        public Command ParseCommand(XmlNode node)
        {
            if (node == null)
                return null;
            Command cmd = null;
            int src, dest, A, B, val;
            switch(node.Name.ToLower())
            {
                case "getglobalvar":
                    src = GetAttribute(node, "src");
                    dest = GetAttribute(node, "dest");
                    cmd = PrimusScriptBuilder.GetGlobalVar(src, dest);
                    break;
                case "putglobalvar":
                    src = GetAttribute(node, "src");
                    dest = GetAttribute(node, "dest");
                    cmd = PrimusScriptBuilder.PutGlobalVar(src, dest);
                    break;
                case "setglobalflag":
                    src = GetAttribute(node, "flag");
                    cmd = PrimusScriptBuilder.SetGlobalFlag(src);
                    break;
                case "unsetglobalflag":
                    src = GetAttribute(node, "flag");
                    cmd = PrimusScriptBuilder.UnsetGlobalFlag(src);
                    break;
                case "setlocalflag":
                    src = GetAttribute(node, "flag");
                    cmd = PrimusScriptBuilder.SetLocalFlag(src);
                    break;
                case "unsetlocalflag":
                    src = GetAttribute(node, "flag");
                    cmd = PrimusScriptBuilder.UnsetLocalFlag(src);
                    break;
                case "setvar":
                    src = GetAttribute(node, "src");
                    dest = GetAttribute(node, "dest");
                    cmd = PrimusScriptBuilder.SetVar(src, dest);
                    break;
                case "setval":
                    val = GetAttribute(node, "val");
                    dest = GetAttribute(node, "dest");
                    cmd = PrimusScriptBuilder.SetVal(val, dest);
                    break;
                case "addvar":
                    A = GetAttribute(node, "A");
                    B = GetAttribute(node, "B");
                    dest = GetAttribute(node, "dest");
                    cmd = PrimusScriptBuilder.AddVar(A,B, dest);
                    break;
                case "minusvar":
                    A = GetAttribute(node, "A");
                    B = GetAttribute(node, "B");
                    dest = GetAttribute(node, "dest");
                    cmd = PrimusScriptBuilder.MinusVar(A, B, dest);
                    break;
                case "multvar":
                    A = GetAttribute(node, "A");
                    B = GetAttribute(node, "B");
                    dest = GetAttribute(node, "dest");
                    cmd = PrimusScriptBuilder.MultVar(A, B, dest);
                    break;
                case "divvar":
                    A = GetAttribute(node, "A");
                    B = GetAttribute(node, "B");
                    dest = GetAttribute(node, "dest");
                    cmd = PrimusScriptBuilder.DivVar(A, B, dest);
                    break;
                case "conditionblock":
                    cmd = ParseConditionBlock(node);
                    break;
                default:
                    cmd = ParseExtendedCommand(node);
                    break;
            }

            if(cmd!=null)
                cmd.SetNext(ParseCommand(node.NextSibling));

            return cmd;
        }
    }
}
