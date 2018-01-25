using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyRedPlanet.PrimusScript.Base
{
    class PrimusScriptEnvironment
    {
        static Dictionary<string, EventManager> allEventManagers;
        static int[] globalVariables;
        static bool[] globalFlags;

        public static void Initialise()
        {
            allEventManagers = new Dictionary<string, EventManager>();
            globalFlags = new bool[256];
            globalVariables = new int[256];
        }

        public static void AddEventManager(String id, EventManager em)
        {
            allEventManagers.Add(id, em);
        }

        public static void ClearEventManagers()
        {
            allEventManagers.Clear();
        }

        public static void RunAllEvents()
        {
            string[] keys = allEventManagers.Keys.ToArray();
            foreach(string key in keys)
            {
                allEventManagers[key].CheckEvents();
            }

            foreach(string key in keys)
            {
                allEventManagers[key].RunStack();
            }
        }

        public static bool IsGlobalFlagSet(int i)
        {
            return globalFlags[i];
        }

        public static void SetGlobalFlag(int i, bool on)
        {
            globalFlags[i] = on;
        }

        public static int GetGlobalVariable(int i)
        {
            return globalVariables[i];
        }

        public static void SetGlobalVariable(int i, int val)
        {
            globalVariables[i] = val;
        }


    }
}
