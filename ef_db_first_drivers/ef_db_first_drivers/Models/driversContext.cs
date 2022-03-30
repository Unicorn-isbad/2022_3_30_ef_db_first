using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ef_db_first_drivers.Models
{
    public partial class driversContext : DbContext
    {
        public driversContext()
        {
        }

        public driversContext(DbContextOptions<driversContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Driver> Drivers { get; set; } = null!;
        public virtual DbSet<Trophy> Trophies { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server =.\\sqlexpress; Database = drivers; Trusted_connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>(entity =>
            {
                entity.Property(e => e.DriverName).IsUnicode(false);
            });

            modelBuilder.Entity<Trophy>(entity =>
            {
                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.Trophies)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Trophies__Driver__3B75D760");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
