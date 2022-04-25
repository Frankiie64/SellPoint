using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Dato.Model
{
    public partial class RedesSociales
    {
        public RedesSociales()
        {
            Entidades = new HashSet<Entidades>();
        }

        [Key]
        public int Id { get; set; }
        [Column("URLPaginaWeb")]
        [StringLength(120)]
        public string UrlpaginaWeb { get; set; }
        [Column("URLFacebook")]
        [StringLength(120)]
        public string Urlfacebook { get; set; }
        [Column("URLInstagram")]
        [StringLength(120)]
        public string Urlinstagram { get; set; }
        [Column("URLTwitter")]
        [StringLength(120)]
        public string Urltwitter { get; set; }
        [Column("URLTikTok")]
        [StringLength(120)]
        public string UrltikTok { get; set; }

        [InverseProperty("IdRedesSocialesNavigation")]
        public virtual ICollection<Entidades> Entidades { get; set; }
    }
}
