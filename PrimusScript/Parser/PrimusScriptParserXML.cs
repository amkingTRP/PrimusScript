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
        List<string> errorLog;
        XmlDocument xmlDoc;
        bool errors;

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

        public override EventManager ParseScriptFile(string filename)
        {
            throw new NotImplementedException();
        }

        public Command ParseCommands(XmlNode node)
        {

        }

        public int GetAttribute(XmlNode node, string attribute)
        {
            string value = "";
            try
            {
                value = node.Attributes[attribute].value;
            }
            catch (Exception)
            {
                LogError("Attribute " + attribute + " not found in " + node.ToString());
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
                
                LogError("Unknown value " + value + " found for attribute " + attribute + " in " + node.ToString())
            }

            return 0;

        }


        public Command ParseCommand(XmlNode node)
        {
            Command cmd = null;
            int src, dest, A, B, val;
            switch(node.Name.ToLower())
            {
                case "getglobalvar":
                    src = Int32.Parse(node.Attributes["src"].Value);
                    dest = Int32.Parse(node.Attributes["dest"].Value);
                    cmd = PrimusScriptBuilder.GetGlobalVar(src, dest);
                    break;
                case "putglobalvar":
                    src = Int32.Parse(node.Attributes["src"].Value);
                    dest = Int32.Parse(node.Attributes["dest"].Value);
                    cmd = PrimusScriptBuilder.PutGlobalVar(src, dest);
                    break;

                default:
                    break;
            }

            return cmd;
        }
    }
}
