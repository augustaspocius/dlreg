using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DLRegIdentity.Models
{
    public partial class dlregContext : DbContext
    {
        public dlregContext()
        {
        }

        public dlregContext(DbContextOptions<dlregContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Devicereg> Devicereg { get; set; }
        public virtual DbSet<Monthreg> Monthreg { get; set; }
        public virtual DbSet<Workers> Workers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("asdfsdfasd");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Devicereg>(entity =>
            {
                entity.ToTable("devicereg");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Deviceid).HasColumnName("DEVICEID");

                entity.Property(e => e.Inout).HasColumnName("INOUT");

                entity.Property(e => e.Recid).HasColumnName("RECID");

                entity.Property(e => e.Time)
                    .HasColumnName("TIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.Workerid).HasColumnName("WORKERID");
            });

            modelBuilder.Entity<Monthreg>(entity =>
            {
                entity.HasKey(e => e.Rowid);

                entity.ToTable("monthreg");

                entity.HasIndex(e => new { e.Monthid, e.Workerid })
                    .HasName("IX_Table_1")
                    .IsUnique();

                entity.Property(e => e.Rowid).HasColumnName("ROWID");

                entity.Property(e => e.Comment)
                    .HasColumnName("COMMENT")
                    .IsUnicode(false);

                entity.Property(e => e.D1).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.D10).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.D11).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.D12).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.D13).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.D14).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.D15).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.D16).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.D17).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.D18).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.D19).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.D2).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.D20).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.D21).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.D22).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.D23).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.D24).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.D25).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.D26).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.D27).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.D28).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.D29).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.D3).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.D30).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.D31).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.D4).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.D5).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.D6).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.D7).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.D8).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.D9).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.Dp1)
                    .HasColumnName("DP1")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Dp10)
                    .HasColumnName("DP10")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Dp11)
                    .HasColumnName("DP11")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Dp12)
                    .HasColumnName("DP12")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Dp13)
                    .HasColumnName("DP13")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Dp14)
                    .HasColumnName("DP14")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Dp15)
                    .HasColumnName("DP15")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Dp16)
                    .HasColumnName("DP16")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Dp17)
                    .HasColumnName("DP17")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Dp18)
                    .HasColumnName("DP18")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Dp19)
                    .HasColumnName("DP19")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Dp2)
                    .HasColumnName("DP2")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Dp20)
                    .HasColumnName("DP20")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Dp21)
                    .HasColumnName("DP21")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Dp22)
                    .HasColumnName("DP22")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Dp23)
                    .HasColumnName("DP23")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Dp24)
                    .HasColumnName("DP24")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Dp25)
                    .HasColumnName("DP25")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Dp26)
                    .HasColumnName("DP26")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Dp27)
                    .HasColumnName("DP27")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Dp28)
                    .HasColumnName("DP28")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Dp29)
                    .HasColumnName("DP29")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Dp3)
                    .HasColumnName("DP3")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Dp30)
                    .HasColumnName("DP30")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Dp31)
                    .HasColumnName("DP31")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Dp4)
                    .HasColumnName("DP4")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Dp5)
                    .HasColumnName("DP5")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Dp6)
                    .HasColumnName("DP6")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Dp7)
                    .HasColumnName("DP7")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Dp8)
                    .HasColumnName("DP8")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Dp9)
                    .HasColumnName("DP9")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Monthid).HasColumnName("MONTHID");

                entity.Property(e => e.Workerid).HasColumnName("WORKERID");

                //entity.HasOne(d => d.Worker)
                    //.WithMany(p => p.Monthreg)
                    //.HasForeignKey(d => d.Workerid)
                   // .OnDelete(DeleteBehavior.ClientSetNull)
                    //.HasConstraintName("FK_monthreg_workers");
            });

            modelBuilder.Entity<Workers>(entity =>
            {
                entity.ToTable("workers");

                entity.HasIndex(e => e.Fullname)
                    .HasName("IX_fullname")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("IX_username")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Departmentid).HasColumnName("DEPARTMENTID");

                entity.Property(e => e.Fullname)
                    .HasColumnName("FULLNAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasColumnName("LASTNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Shiftid).HasColumnName("SHIFTID");

                entity.Property(e => e.Username)
                    .HasColumnName("USERNAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
