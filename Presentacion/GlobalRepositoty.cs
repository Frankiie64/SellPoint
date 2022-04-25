using Dato.Model;
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
        public int IdEntidad = 0;
        public int IdRedSocial = 0;


        public RedesSociales RedesSociales;
        public Dato.Model.Entidades entidadad;
        private GlobalRepositoty()
        {

        }
    }
}
