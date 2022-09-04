using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ActivityTest.ModelsDB
{
    public partial class DB_Context : DbContext
    {
        public DB_Context()
        {
        }

        public DB_Context(DbContextOptions<DB_Context> options)
            : base(options)
        {
        }

        public virtual DbSet<BCRM_MQDC_Activity> BCRM_MQDC_Activities { get; set; }
        public virtual DbSet<BCRM_MQDC_Activity_Period> BCRM_MQDC_Activity_Periods { get; set; }
        public virtual DbSet<BCRM_MQDC_Limitation> BCRM_MQDC_Limitations { get; set; }
        public virtual DbSet<BCRM_MQDC_Project> BCRM_MQDC_Projects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost,1433;Database=TestDB;User id=sa;Password=Keng1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BCRM_MQDC_Activity>(entity =>
            {
                entity.HasKey(e => e.Activity_info_id)
                    .HasName("PK__BCRM_MQD__52461C076CA5CC15");

                entity.ToTable("BCRM_MQDC_Activity");

                entity.Property(e => e.Activity_Image_Url_Cover).HasMaxLength(1000);

                entity.Property(e => e.Activity_Image_Url_Square).HasMaxLength(1000);

                entity.Property(e => e.Name_en).HasMaxLength(500);

                entity.Property(e => e.Name_th).HasMaxLength(500);

                entity.Property(e => e.Remark).HasMaxLength(1000);
            });

            modelBuilder.Entity<BCRM_MQDC_Activity_Period>(entity =>
            {
                entity.HasKey(e => e.Activity_period_id)
                    .HasName("PK__BCRM_MQD__35ED53C1920FA880");

                entity.ToTable("BCRM_MQDC_Activity_Period");

                entity.Property(e => e.Remark).HasMaxLength(1000);

                entity.HasOne(d => d.Activity_info)
                    .WithMany(p => p.BCRM_MQDC_Activity_Periods)
                    .HasForeignKey(d => d.Activity_info_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BCRM_MQDC__Activ__2F10007B");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.BCRM_MQDC_Activity_Periods)
                    .HasForeignKey(d => d.Project_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BCRM_MQDC__Proje__300424B4");
            });

            modelBuilder.Entity<BCRM_MQDC_Limitation>(entity =>
            {
                entity.HasKey(e => e.Limit_id)
                    .HasName("PK__BCRM_MQD__40FBB452BCDA547B");

                entity.ToTable("BCRM_MQDC_Limitation");

                entity.Property(e => e.Remark).HasMaxLength(1000);

                entity.HasOne(d => d.Activity_info)
                    .WithMany(p => p.BCRM_MQDC_Limitations)
                    .HasForeignKey(d => d.Activity_info_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BCRM_MQDC__Activ__267ABA7A");
            });

            modelBuilder.Entity<BCRM_MQDC_Project>(entity =>
            {
                entity.HasKey(e => e.Project_id)
                    .HasName("PK__BCRM_MQD__1CBA227B30902A59");

                entity.ToTable("BCRM_MQDC_Project");

                entity.Property(e => e.Project_name_en).HasMaxLength(500);

                entity.Property(e => e.Project_name_th).HasMaxLength(500);

                entity.Property(e => e.Remark).HasMaxLength(1000);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
