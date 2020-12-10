using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UserService.Data;

namespace UserService.Models
{
    public static class InitDb
    {

        public static void PrePopulate(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<UserContext>());
            }
            
        }

        public static void SeedData(UserContext context)
        {  
            context.Database.Migrate();

            if(!context.Users.Any())
            {   
                Console.WriteLine("Initialising DB with data ...");
                context.Users.AddRange(
                    new User(){FullName="JOHN WICK", Email="john@test.com", Phone="023455532", Age=39},
                    new User(){FullName="DAVID BECKHAM", Email="david@test.com"},
                    new User(){FullName="ROSETTA STONE", Email="rosetta@test.com", Age=21},
                    new User(){FullName="NELSON MANDELA", Email="nelson@test.com", Phone="8723897443"}
                );
                context.SaveChanges();
            }
        }
    }
}