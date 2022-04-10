using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Dato.Model
{
    public partial class NoEliminable
    {
        public NoEliminable()
        {
            Entidades = new HashSet<Entidades>();
            GruposEntidades = new HashSet<GruposEntidades>();
            TipoEntidades = new HashSet<TipoEntidades>();
        }

        [Key]
        public bool Id { get; set; }
        [StringLength(5)]
        public string Estado { get; set; }

        [InverseProperty("IdNoEliminableNavigation")]
        public virtual ICollection<Entidades> Entidades { get; set; }
        [InverseProperty("IdNoEliminableNavigation")]
        public virtual ICollection<GruposEntidades> GruposEntidades { get; set; }
        [InverseProperty("IdNoEliminableNavigation")]
        public virtual ICollection<TipoEntidades> TipoEntidades { get; set; }
    }
}
