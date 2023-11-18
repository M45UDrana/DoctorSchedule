using Microsoft.EntityFrameworkCore;
using AppointmentService.Core.Models;

namespace AppointmentService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
        }

        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Schedule>()
                .HasMany(s => s.Appointments)
                .WithOne(s=> s.Schedule!)
                .HasForeignKey(s => s.ScheduleId);

            modelBuilder
                .Entity<Appointment>()
                .HasOne(a => a.Schedule)
                .WithMany(p => p.Appointments)
                .HasForeignKey(p =>p.ScheduleId);
        }
    }
}