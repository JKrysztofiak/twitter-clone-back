using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TwitterClone
{
    public partial class twittercloneContext : DbContext
    {
        public twittercloneContext()
        {
        }

        public twittercloneContext(DbContextOptions<twittercloneContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Messages> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Server=localhost;Database=twitterclone;User Id=postgres;Password=kuba27950;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Messages>(entity =>
            {
                entity.HasKey(e => e.Messageid)
                    .HasName("pk_messages");

                entity.ToTable("messages");

                entity.Property(e => e.Messageid)
                    .HasColumnName("messageid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Messagetext)
                    .HasColumnName("messagetext")
                    .HasMaxLength(255);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
