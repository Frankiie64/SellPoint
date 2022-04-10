using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Dato.Model
{
    public partial class TipoDocumento
    {
        public TipoDocumento()
        {
            Entidades = new HashSet<Entidades>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(9)]
        public string Documento { get; set; }

        [InverseProperty("IdTipoDocumentoNavigation")]
        public virtual ICollection<Entidades> Entidades { get; set; }
    }
}
