/*using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity;

namespace BeanSceneReservationApp.Models;

public partial class BeanSeanReservationDbContext : DbContext
{
    public BeanSeanReservationDbContext()
    {
    }

    public BeanSeanReservationDbContext(DbContextOptions<BeanSeanReservationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<RestaurantTable> RestaurantTables { get; set; }

    public virtual DbSet<SittingSchedule> SittingSchedules { get; set; }

    public virtual DbSet<Staff> Staffs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BeanSeanReservationDB;Trusted_Connection=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.AreaId).HasName("PK__Areas__70B82028021F9B83");

            entity.Property(e => e.AreaId).HasColumnName("AreaID");
            entity.Property(e => e.AreaName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.MemberId).HasName("PK__Members__0CF04B385D3E9B78");

            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("PK__Reservat__B7EE5F048FA4C04B");

            entity.Property(e => e.ReservationId).HasColumnName("ReservationID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.GuestName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
            entity.Property(e => e.Notes).HasColumnType("text");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ReservationSource)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReservationStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SittingId).HasColumnName("SittingID");
            entity.Property(e => e.StartTime).HasColumnType("datetime");
            entity.Property(e => e.TableId).HasColumnName("TableID");

            entity.HasOne(d => d.Member).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK__Reservati__Membe__44FF419A");

            entity.HasOne(d => d.Sitting).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.SittingId)
                .HasConstraintName("FK__Reservati__Sitti__4316F928");

            entity.HasOne(d => d.Table).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.TableId)
                .HasConstraintName("FK__Reservati__Table__440B1D61");
        });

        modelBuilder.Entity<RestaurantTable>(entity =>
        {
            entity.HasKey(e => e.TableId).HasName("PK__Restaura__7D5F018EB4DAC4D3");

            entity.Property(e => e.TableId).HasColumnName("TableID");
            entity.Property(e => e.AreaId).HasColumnName("AreaID");
            entity.Property(e => e.TableName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TableStatus)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Area).WithMany(p => p.RestaurantTables)
                .HasForeignKey(d => d.AreaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Restauran__AreaI__398D8EEE");
        });

        modelBuilder.Entity<SittingSchedule>(entity =>
        {
            entity.HasKey(e => e.SittingId).HasName("PK__SittingS__42A14C30276D7D03");

            entity.Property(e => e.SittingId).HasColumnName("SittingID");
            entity.Property(e => e.EndDateTime).HasColumnType("datetime");
            entity.Property(e => e.Scapacity).HasColumnName("SCapacity");
            entity.Property(e => e.StartDateTime).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Stype)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SType");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staffs__96D4AAF742C351A4");

            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.StaffType)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
*/
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeanSceneReservationApp.Models
{
    public partial class BeanSeanReservationDbContext : IdentityDbContext<ApplicationUser>
    {
        public BeanSeanReservationDbContext(DbContextOptions<BeanSeanReservationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<RestaurantTable> RestaurantTables { get; set; }
        public virtual DbSet<SittingSchedule> SittingSchedules { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 

            modelBuilder.Entity<Area>(entity =>
            {
                entity.HasKey(e => e.AreaId).HasName("PK__Areas__70B82028021F9B83");

                entity.Property(e => e.AreaId).HasColumnName("AreaID");
                entity.Property(e => e.AreaName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasKey(e => e.MemberId).HasName("PK__Members__0CF04B385D3E9B78");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");
                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(e => e.ReservationId).HasName("PK__Reservat__B7EE5F048FA4C04B");

                entity.Property(e => e.ReservationId).HasColumnName("ReservationID");
                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.GuestName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.MemberId).HasColumnName("MemberID");
                entity.Property(e => e.Notes).HasColumnType("text");
                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.ReservationSource)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.ReservationStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.SittingId).HasColumnName("SittingID");
                entity.Property(e => e.StartTime).HasColumnType("datetime");
                entity.Property(e => e.TableId).HasColumnName("TableID");

                entity.HasOne(d => d.Member).WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK__Reservati__Membe__44FF419A");

                entity.HasOne(d => d.Sitting).WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.SittingId)
                    .HasConstraintName("FK__Reservati__Sitti__4316F928");

                entity.HasOne(d => d.Table).WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.TableId)
                    .HasConstraintName("FK__Reservati__Table__440B1D61");
            });

            modelBuilder.Entity<RestaurantTable>(entity =>
            {
                entity.HasKey(e => e.TableId).HasName("PK__Restaura__7D5F018EB4DAC4D3");

                entity.Property(e => e.TableId).HasColumnName("TableID");
                entity.Property(e => e.AreaId).HasColumnName("AreaID");
                entity.Property(e => e.TableName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.TableStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Area).WithMany(p => p.RestaurantTables)
                    .HasForeignKey(d => d.AreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Restauran__AreaI__398D8EEE");
            });

            modelBuilder.Entity<SittingSchedule>(entity =>
            {
                entity.HasKey(e => e.SittingId).HasName("PK__SittingS__42A14C30276D7D03");

                entity.Property(e => e.SittingId).HasColumnName("SittingID");
                entity.Property(e => e.EndDateTime).HasColumnType("datetime");
                entity.Property(e => e.Scapacity).HasColumnName("SCapacity");
                entity.Property(e => e.StartDateTime).HasColumnType("datetime");
                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Stype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SType");
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.HasKey(e => e.StaffId).HasName("PK__Staffs__96D4AAF742C351A4");

                entity.Property(e => e.StaffId).HasColumnName("StaffID");
                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.StaffType)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }



        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

    
}
