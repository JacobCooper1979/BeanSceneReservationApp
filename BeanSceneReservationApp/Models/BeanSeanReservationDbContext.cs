using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
        public virtual DbSet<Staff> Staffs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Area>(entity =>
            {
                entity.HasKey(e => e.AreaId);
                entity.Property(e => e.AreaName).IsRequired().HasMaxLength(255);
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasKey(e => e.MemberId);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(255);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Password).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Phone).HasMaxLength(20);
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(e => e.ReservationId);
                entity.Property(e => e.GuestName).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Email).HasMaxLength(255);
                entity.Property(e => e.Phone).HasMaxLength(20);
                entity.Property(e => e.ReservationSource).HasMaxLength(50);
                entity.Property(e => e.ReservationStatus).HasMaxLength(50);
                entity.Property(e => e.StartTime).HasColumnType("datetime");
                entity.Property(e => e.Notes).HasColumnType("text");
                entity.HasOne(d => d.Table).WithMany(p => p.Reservations).HasForeignKey(d => d.TableId);
            });

            modelBuilder.Entity<RestaurantTable>(entity =>
            {
                entity.HasKey(e => e.TableId);
                entity.Property(e => e.TableName).IsRequired().HasMaxLength(255);
                entity.Property(e => e.TableStatus).HasMaxLength(50);
                entity.Property(e => e.AreaName).IsRequired(); // Remove maximum length and required constraint
                entity.Property(e => e.AreaName).HasConversion<int>(); // Configure AreaName as an enumeration
            });



            modelBuilder.Entity<Staff>(entity =>
            {
                entity.HasKey(e => e.StaffId);
                entity.Property(e => e.Email).HasMaxLength(255);
                entity.Property(e => e.FirstName).HasMaxLength(255);
                entity.Property(e => e.LastName).HasMaxLength(255);
                entity.Property(e => e.Password).HasMaxLength(255);
                entity.Property(e => e.Phone).HasMaxLength(20);
                entity.Property(e => e.StaffType).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
