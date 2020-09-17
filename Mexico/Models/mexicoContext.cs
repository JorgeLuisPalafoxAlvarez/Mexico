using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Mexico.Models
{
    public partial class mexicoContext : DbContext
    {
        public mexicoContext()
        {
        }

        public mexicoContext(DbContextOptions<mexicoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Estados> Estados { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=mexico", x => x.ServerVersion("5.7.31-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estados>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("estados");

                entity.Property(e => e.Abrev)
                    .IsRequired()
                    .HasColumnName("abrev")
                    .HasColumnType("varchar(10)")
                    .HasComment("NOM_ABR - Nombre abreviado de la entidad")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(40)")
                    .HasComment("NOM_ENT - Nombre de la entidad")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
