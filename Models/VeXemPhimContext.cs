using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BookingMovie.Models
{
    public partial class VeXemPhimContext : DbContext
    {
        public VeXemPhimContext()
        {
        }

        public VeXemPhimContext(DbContextOptions<VeXemPhimContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChiTietChieu> ChiTietChieus { get; set; }
        public virtual DbSet<Phim> Phims { get; set; }
        public virtual DbSet<Phong> Phongs { get; set; }
        public virtual DbSet<TheLoai> TheLoais { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Ve> Ves { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-6IPCPV6\\DEVILS;Database=VeXemPhim;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ChiTietChieu>(entity =>
            {
                entity.HasKey(e => e.IdChiTietChieu);

                entity.ToTable("ChiTietChieu");

                entity.Property(e => e.GioBatDau).HasColumnType("datetime");

                entity.Property(e => e.NgayChieu).HasColumnType("datetime");

                entity.HasOne(d => d.IdPhimNavigation)
                    .WithMany(p => p.ChiTietChieus)
                    .HasForeignKey(d => d.IdPhim)
                    .HasConstraintName("FK_ChiTietChieu_Phim");

                entity.HasOne(d => d.IdPhongNavigation)
                    .WithMany(p => p.ChiTietChieus)
                    .HasForeignKey(d => d.IdPhong)
                    .HasConstraintName("FK_ChiTietChieu_Phong");
            });

            modelBuilder.Entity<Phim>(entity =>
            {
                entity.HasKey(e => e.IdPhim);

                entity.ToTable("Phim");

                entity.Property(e => e.Image)
                    .HasMaxLength(200)
                    .HasColumnName("image");

                entity.Property(e => e.TenPhim).HasMaxLength(100);

                entity.Property(e => e.ThoiLuong).HasMaxLength(50);

                entity.HasOne(d => d.IdTheLoaiNavigation)
                    .WithMany(p => p.Phims)
                    .HasForeignKey(d => d.IdTheLoai)
                    .HasConstraintName("FK_Phim_TheLoai");
            });

            modelBuilder.Entity<Phong>(entity =>
            {
                entity.HasKey(e => e.IdPhong);

                entity.ToTable("Phong");

                entity.Property(e => e.TenPhong)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TheLoai>(entity =>
            {
                entity.HasKey(e => e.IdTheLoai);

                entity.ToTable("TheLoai");

                entity.Property(e => e.TenTheLoai)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("User");

                entity.Property(e => e.DiaChi)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.HoTen)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MatKhau)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Sdt)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsFixedLength(true);

                entity.Property(e => e.TaiKhoan)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Ve>(entity =>
            {
                entity.HasKey(e => e.MaVe);

                entity.ToTable("Ve");

                entity.HasOne(d => d.IdChiTietChieuNavigation)
                    .WithMany(p => p.Ves)
                    .HasForeignKey(d => d.IdChiTietChieu)
                    .HasConstraintName("FK_Ve_ChiTietChieu");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Ves)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_Ve_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
