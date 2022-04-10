using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Dato.Model
{
    public partial class TipoEntidades
    {
        public TipoEntidades()
        {
            Entidades = new HashSet<Entidades>();
        }

        [Key]
        [Column(TypeName = "numeric(10, 0)")]
        public decimal IdTipoEntidades { get; set; }
        [Required]
        [StringLength(120)]
        public string Descripcion { get; set; }
        [Column(TypeName = "numeric(10, 0)")]
        public decimal? IdGrupoEntidad { get; set; }
        [Column(TypeName = "text")]
        public string Comentario { get; set; }
        public int IdStatus { get; set; }
        public bool IdNoEliminable { get; set; }
        [Column(TypeName = "date")]
        public DateTime? FechaRegistro { get; set; }

        [ForeignKey(nameof(IdGrupoEntidad))]
        [InverseProperty(nameof(GruposEntidades.TipoEntidades))]
        public virtual GruposEntidades IdGrupoEntidadNavigation { get; set; }
        [ForeignKey(nameof(IdNoEliminable))]
        [InverseProperty(nameof(NoEliminable.TipoEntidades))]
        public virtual NoEliminable IdNoEliminableNavigation { get; set; }
        [ForeignKey(nameof(IdStatus))]
        [InverseProperty(nameof(RolUserEntidad.TipoEntidades))]
        public virtual RolUserEntidad IdStatusNavigation { get; set; }
        [InverseProperty("IdTipoEntidadNavigation")]
        public virtual ICollection<Entidades> Entidades { get; set; }
    }
}
