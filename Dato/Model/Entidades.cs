using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Dato.Model
{
    public partial class Entidades
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(120)]
        public string Descripcion { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string Direccion { get; set; }
        [Required]
        [StringLength(40)]
        public string Localidad { get; set; }
        public int IdTipoEntidadPolitica { get; set; }
        public int IdTipoDocumento { get; set; }
        [Required]
        [StringLength(60)]
        public string Télefono { get; set; }
        public int IdRedesSociales { get; set; }
        [Column(TypeName = "numeric(10, 0)")]
        public decimal? IdGrupoEntidad { get; set; }
        [Column(TypeName = "numeric(10, 0)")]
        public decimal? IdTipoEntidad { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? LimiteCredito { get; set; }
        [Required]
        [StringLength(60)]
        public string UsernameEntidad { get; set; }
        [Required]
        [StringLength(30)]
        public string PasswordEntidad { get; set; }
        public int IdRolUserEntidad { get; set; }
        [Column(TypeName = "text")]
        public string Comentario { get; set; }
        public int IdStatus { get; set; }
        public bool IdNoEliminable { get; set; }
        [Column(TypeName = "date")]
        public DateTime? FechaRegistro { get; set; }
        [StringLength(100)]
        public string Email { get; set; }

        [ForeignKey(nameof(IdGrupoEntidad))]
        [InverseProperty(nameof(GruposEntidades.Entidades))]
        public virtual GruposEntidades IdGrupoEntidadNavigation { get; set; }
        [ForeignKey(nameof(IdNoEliminable))]
        [InverseProperty(nameof(NoEliminable.Entidades))]
        public virtual NoEliminable IdNoEliminableNavigation { get; set; }
        [ForeignKey(nameof(IdRedesSociales))]
        [InverseProperty(nameof(RedesSociales.Entidades))]
        public virtual RedesSociales IdRedesSocialesNavigation { get; set; }
        [ForeignKey(nameof(IdRolUserEntidad))]
        [InverseProperty(nameof(RolUserEntidad.EntidadesIdRolUserEntidadNavigation))]
        public virtual RolUserEntidad IdRolUserEntidadNavigation { get; set; }
        [ForeignKey(nameof(IdStatus))]
        [InverseProperty(nameof(RolUserEntidad.EntidadesIdStatusNavigation))]
        public virtual RolUserEntidad IdStatusNavigation { get; set; }
        [ForeignKey(nameof(IdTipoDocumento))]
        [InverseProperty(nameof(TipoDocumento.Entidades))]
        public virtual TipoDocumento IdTipoDocumentoNavigation { get; set; }
        [ForeignKey(nameof(IdTipoEntidad))]
        [InverseProperty(nameof(TipoEntidades.Entidades))]
        public virtual TipoEntidades IdTipoEntidadNavigation { get; set; }
        [ForeignKey(nameof(IdTipoEntidadPolitica))]
        [InverseProperty(nameof(TipoEntidadPolitica.Entidades))]
        public virtual TipoEntidadPolitica IdTipoEntidadPoliticaNavigation { get; set; }
    }
}
