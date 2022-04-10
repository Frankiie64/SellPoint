using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Dato.Model
{
    public partial class Modelos : DbContext
    {
        public Modelos()
        {
        }

        public Modelos(DbContextOptions<Modelos> options)
            : base(options)
        {
        }

        public virtual DbSet<Entidades> Entidades { get; set; }
        public virtual DbSet<GruposEntidades> GruposEntidades { get; set; }
        public virtual DbSet<NoEliminable> NoEliminable { get; set; }
        public virtual DbSet<RedesSociales> RedesSociales { get; set; }
        public virtual DbSet<RolUserEntidad> RolUserEntidad { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumento { get; set; }
        public virtual DbSet<TipoEntidadPolitica> TipoEntidadPolitica { get; set; }
        public virtual DbSet<TipoEntidades> TipoEntidades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("workstation id=Prog2Final.mssql.somee.com;packet size=4096;user id=Jesus12112002_SQLLogin_1;pwd=94z9r9vhjq;data source=Prog2Final.mssql.somee.com;persist security info=False;initial catalog=Prog2Final");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entidades>(entity =>
            {
                entity.Property(e => e.Email).IsFixedLength();

                entity.Property(e => e.FechaRegistro).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdRedesSociales).HasDefaultValueSql("((1))");

                entity.Property(e => e.IdRolUserEntidad).HasDefaultValueSql("((1))");

                entity.Property(e => e.IdStatus).HasDefaultValueSql("((1))");

                entity.Property(e => e.IdTipoDocumento).HasDefaultValueSql("((1))");

                entity.Property(e => e.IdTipoEntidadPolitica).HasDefaultValueSql("((1))");

                entity.Property(e => e.LimiteCredito).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdGrupoEntidadNavigation)
                    .WithMany(p => p.Entidades)
                    .HasForeignKey(d => d.IdGrupoEntidad)
                    .HasConstraintName("FK__Entidades__IdGru__412EB0B6");

                entity.HasOne(d => d.IdNoEliminableNavigation)
                    .WithMany(p => p.Entidades)
                    .HasForeignKey(d => d.IdNoEliminable)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Entidades__IdNoE__4222D4EF");

                entity.HasOne(d => d.IdRedesSocialesNavigation)
                    .WithMany(p => p.Entidades)
                    .HasForeignKey(d => d.IdRedesSociales)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Entidades__IdRed__4316F928");

                entity.HasOne(d => d.IdRolUserEntidadNavigation)
                    .WithMany(p => p.EntidadesIdRolUserEntidadNavigation)
                    .HasForeignKey(d => d.IdRolUserEntidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Entidades__IdRol__440B1D61");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.EntidadesIdStatusNavigation)
                    .HasForeignKey(d => d.IdStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Entidades__IdSta__44FF419A");

                entity.HasOne(d => d.IdTipoDocumentoNavigation)
                    .WithMany(p => p.Entidades)
                    .HasForeignKey(d => d.IdTipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Entidades__IdTip__46E78A0C");

                entity.HasOne(d => d.IdTipoEntidadNavigation)
                    .WithMany(p => p.Entidades)
                    .HasForeignKey(d => d.IdTipoEntidad)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Entidades__IdTip__47DBAE45");

                entity.HasOne(d => d.IdTipoEntidadPoliticaNavigation)
                    .WithMany(p => p.Entidades)
                    .HasForeignKey(d => d.IdTipoEntidadPolitica)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Entidades__IdTip__45F365D3");
            });

            modelBuilder.Entity<GruposEntidades>(entity =>
            {
                entity.HasKey(e => e.IdGrupoEnitdad)
                    .HasName("PK__GruposEn__7AA59530EC5B4331");

                entity.Property(e => e.IdGrupoEnitdad).ValueGeneratedOnAdd();

                entity.Property(e => e.FechaRegistro).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdStatus).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdNoEliminableNavigation)
                    .WithMany(p => p.GruposEntidades)
                    .HasForeignKey(d => d.IdNoEliminable)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GruposEnt__IdNoE__48CFD27E");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.GruposEntidades)
                    .HasForeignKey(d => d.IdStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GruposEnt__IdSta__49C3F6B7");
            });

            modelBuilder.Entity<NoEliminable>(entity =>
            {
                entity.Property(e => e.Estado).IsUnicode(false);
            });

            modelBuilder.Entity<RedesSociales>(entity =>
            {
                entity.Property(e => e.Urlfacebook).IsUnicode(false);

                entity.Property(e => e.Urlinstagram).IsUnicode(false);

                entity.Property(e => e.UrlpaginaWeb).IsUnicode(false);

                entity.Property(e => e.UrltikTok).IsUnicode(false);

                entity.Property(e => e.Urltwitter).IsUnicode(false);
            });

            modelBuilder.Entity<RolUserEntidad>(entity =>
            {
                entity.Property(e => e.Rol).IsUnicode(false);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.Estado).IsUnicode(false);
            });

            modelBuilder.Entity<TipoDocumento>(entity =>
            {
                entity.Property(e => e.Documento).IsUnicode(false);
            });

            modelBuilder.Entity<TipoEntidadPolitica>(entity =>
            {
                entity.Property(e => e.Rol).IsUnicode(false);
            });

            modelBuilder.Entity<TipoEntidades>(entity =>
            {
                entity.HasKey(e => e.IdTipoEntidades)
                    .HasName("PK__TipoEnti__569C0B4DF98C695C");

                entity.Property(e => e.IdTipoEntidades).ValueGeneratedOnAdd();

                entity.Property(e => e.FechaRegistro).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdStatus).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdGrupoEntidadNavigation)
                    .WithMany(p => p.TipoEntidades)
                    .HasForeignKey(d => d.IdGrupoEntidad)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__TipoEntid__IdGru__4AB81AF0");

                entity.HasOne(d => d.IdNoEliminableNavigation)
                    .WithMany(p => p.TipoEntidades)
                    .HasForeignKey(d => d.IdNoEliminable)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TipoEntid__IdNoE__4BAC3F29");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.TipoEntidades)
                    .HasForeignKey(d => d.IdStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TipoEntid__IdSta__4CA06362");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
