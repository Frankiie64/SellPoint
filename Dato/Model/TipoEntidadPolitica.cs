using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Dato.Model
{
    public partial class TipoEntidadPolitica
    {
        public TipoEntidadPolitica()
        {
            Entidades = new HashSet<Entidades>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(8)]
        public string Rol { get; set; }

        [InverseProperty("IdTipoEntidadPoliticaNavigation")]
        public virtual ICollection<Entidades> Entidades { get; set; }
    }
}
