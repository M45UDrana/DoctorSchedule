using Microsoft.EntityFrameworkCore;
using ScheduleService.Core.Models;

namespace ScheduleService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Doctor>()
                .HasMany(p => p.Schedules)
                .WithOne(p=> p.Doctor!)
                .HasForeignKey(p => p.DoctorId);

            modelBuilder
                .Entity<Schedule>()
                .HasOne(p => p.Doctor)
                .WithMany(p => p.Schedules)
                .HasForeignKey(p =>p.DoctorId);
        }
    }
}