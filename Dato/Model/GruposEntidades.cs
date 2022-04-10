using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Dato.Model
{
    public partial class GruposEntidades
    {
        public GruposEntidades()
        {
            Entidades = new HashSet<Entidades>();
            TipoEntidades = new HashSet<TipoEntidades>();
        }

        [Key]
        [Column(TypeName = "numeric(10, 0)")]
        public decimal IdGrupoEnitdad { get; set; }
        [Required]
        [StringLength(120)]
        public string Descripcion { get; set; }
        [Column(TypeName = "text")]
        public string Comentario { get; set; }
        public int IdStatus { get; set; }
        public bool IdNoEliminable { get; set; }
        [Column(TypeName = "date")]
        public DateTime? FechaRegistro { get; set; }

        [ForeignKey(nameof(IdNoEliminable))]
        [InverseProperty(nameof(NoEliminable.GruposEntidades))]
        public virtual NoEliminable IdNoEliminableNavigation { get; set; }
        [ForeignKey(nameof(IdStatus))]
        [InverseProperty(nameof(RolUserEntidad.GruposEntidades))]
        public virtual RolUserEntidad IdStatusNavigation { get; set; }
        [InverseProperty("IdGrupoEntidadNavigation")]
        public virtual ICollection<Entidades> Entidades { get; set; }
        [InverseProperty("IdGrupoEntidadNavigation")]
        public virtual ICollection<TipoEntidades> TipoEntidades { get; set; }
    }
}
