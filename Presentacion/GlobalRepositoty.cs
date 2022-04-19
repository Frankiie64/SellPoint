using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    public sealed class GlobalRepositoty
    {
        public static GlobalRepositoty Instance { get; } = new GlobalRepositoty();

        public bool value = true;
        private GlobalRepositoty()
        {

        }
    }
}
