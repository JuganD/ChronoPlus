using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ChronoPlus.Controller;
using ChronoPlus.Core.Abstraction;

namespace ChronoPlus.Lightweight.Windows
{
    public class Controller : ChronoController
    {
        private static Controller Instance;
        public static bool Instantiated = false;
        public static Controller GetInstance(string key = "")
        {
            if (Instance == null)
            {
                Instantiated = true;
                Instance = new Controller(key);
            }
            return Instance;
        }

        public static void DestroyInstance()
        {
            if (Instance != null)
            {
                Instance.Dispose();
                Instance = null;
                Instantiated = false;
            }
        }
        public Controller(string key) : base(key)
        {
            
        }
        protected override void Configure(IChronoConnectionSettings settings)
        {
            
        }
    }
}
