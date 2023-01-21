using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IHost app)
        {
            using( var serviceScope = app.Services.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetRequiredService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if(!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding Data...");
                
                context.Platforms.AddRange(
                    new Platform() {Name="Asp Dot Net", Publisher="Microsoft", Cost="Free"},
                    new Platform() {Name="SQL Server", Publisher="Microsoft", Cost="Free"},
                    new Platform() {Name="Kubernetes - K8s", Publisher="Cloud Native Computing Foundation", Cost="Free"}
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We are done with data seeding...");
            }
        }
    }
}