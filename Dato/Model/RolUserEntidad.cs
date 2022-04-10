using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Dato.Model
{
    public partial class RolUserEntidad
    {
        public RolUserEntidad()
        {
            EntidadesIdRolUserEntidadNavigation = new HashSet<Entidades>();
            EntidadesIdStatusNavigation = new HashSet<Entidades>();
            GruposEntidades = new HashSet<GruposEntidades>();
            TipoEntidades = new HashSet<TipoEntidades>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(60)]
        public string Rol { get; set; }

        [InverseProperty(nameof(Entidades.IdRolUserEntidadNavigation))]
        public virtual ICollection<Entidades> EntidadesIdRolUserEntidadNavigation { get; set; }
        [InverseProperty(nameof(Entidades.IdStatusNavigation))]
        public virtual ICollection<Entidades> EntidadesIdStatusNavigation { get; set; }
        [InverseProperty("IdStatusNavigation")]
        public virtual ICollection<GruposEntidades> GruposEntidades { get; set; }
        [InverseProperty("IdStatusNavigation")]
        public virtual ICollection<TipoEntidades> TipoEntidades { get; set; }
    }
}
