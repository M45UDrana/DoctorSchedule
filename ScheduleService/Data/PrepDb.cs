using Microsoft.EntityFrameworkCore;
using ScheduleService.Core.Models;

namespace ScheduleService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(WebApplication app)
        {
            bool isProd = app.Environment.IsProduction();
            using( var serviceScope = app.Services.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetRequiredService<AppDbContext>(), isProd);
            }
        }

        private static void SeedData(AppDbContext context, bool isProd)
        {
            if(isProd)
            {
                    context.Database.Migrate();
            }
            
            if(!context.Doctors.Any())
            {
                context.Doctors.AddRange
                (
                    new Doctor {Name = "Dr Doc1",ChamberAddress = "Dhaka 1"},
                    new Doctor {Name = "Dr Doc2",ChamberAddress = "Dhaka 2"},
                    new Doctor {Name = "Dr Doc3",ChamberAddress = "Dhaka 3"},
                    new Doctor {Name = "Dr Doc4",ChamberAddress = "Dhaka 4"}
                );

                context.Schedules.AddRange
                (
                    new Schedule {DoctorId = 1, StartTime = DateTime.Now},
                    new Schedule {DoctorId = 2, StartTime = DateTime.Now}
                );

                context.SaveChanges();
            }
        }
    }
}