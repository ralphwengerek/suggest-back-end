using System;
using CourseSuggestApi.Data;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Collections.Generic;
using CourseSuggestApi.Data.Model;

namespace CourseSuggestApi
{
    public static class Seeder
    {
        public static void SeedDatabase(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<SuggestDbContext>();

            if (!context.Users.Any())
            {
                var users = new List<User>
                {
                    new User { UserId = 1, FirstName = "John", LastName = "Doe", Age = 20, Nationality = "German" },
                    new User { UserId = 2, FirstName = "Mike", LastName = "Merry", Age = 25, Nationality = "English" },
                    new User { UserId = 3, FirstName = "Pete", LastName = "Pratt", Age = 30, Nationality = "Polish" },
                    new User { UserId = 4, FirstName = "Barry", LastName = "Bowman", Age = 35, Nationality = "South African" },
                    new User { UserId = 5, FirstName = "Luke", LastName = "Letterman", Age = 40, Nationality = "Estonian" }
                };

                context.Users.AddRange(users);

                context.SaveChanges();

               
            }
        }
    }
}


