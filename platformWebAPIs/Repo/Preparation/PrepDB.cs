using Entites; 
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repo.Preparation
{
    public static class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app,bool isProd)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<DBContext>(), isProd);
            }
        }

        private static void SeedData(DBContext context,bool isProd)
        {
            if (isProd)
            {
                Console.WriteLine("--> Attempting to apply migrations...");
                try
                {
                    context.Database.Migrate();
                }catch(Exception ex)
                {
                    Console.WriteLine($"--> Could not run migrations: {ex.Message}");
                }
            }

            if (!context.platfroms.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                context.platfroms.AddRange(
                    new Platfrom() { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
                    new Platfrom() { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free" },
                    new Platfrom() { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" }
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}
