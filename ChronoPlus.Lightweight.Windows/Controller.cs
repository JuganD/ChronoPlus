using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChronoPlus.Controller;
using ChronoPlus.Core.Abstraction;

namespace ChronoPlus.Lightweight.Windows
{
    public class Controller : ChronoController
    {
        public Controller(string key) : base(key)
        {
            
        }
        protected override void Configure(IChronoConnectionSettings settings)
        {
            
        }
    }
}
