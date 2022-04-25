using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ModelosDto
{
    public class GruposEntidadesDto
    {
        public decimal IdGrupoEnitdad { get; set; }
  
        public string Descripcion { get; set; }
        public string Comentario { get; set; }
        public int IdStatus { get; set; }
        public bool IdNoEliminable { get; set; }
        public DateTime? FechaRegistro { get; set; }

    }
}
