using System;
using System.Collections.Generic;
using CourseSuggestApi.Data;
using CourseSuggestApi.Data.Model;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Linq;

namespace CourseSuggestApi.Tests
{
    public class UserRepositoryTests
    {
        [Fact]
        public void DatabaseIsSeeded()
        {

        }


        private IUserRepository GetInMemoryUserRepository()
        {
            var options = new DbContextOptionsBuilder<SuggestDbContext>()
                .UseInMemoryDatabase(databaseName: "SuggestDatabase")
                .Options;

            var suggestDbContext = new SuggestDbContext(options);
            suggestDbContext.Database.EnsureDeleted();
            suggestDbContext.Database.EnsureCreated();

            var repo = new UserRepository(suggestDbContext);

            if (!repo.Context.Users.Any())
            {
                var users = new List<User>
                {
                    new User { UserId = 1, FirstName = "John", LastName = "Doe", Age = 20, Nationality = "German" },
                    new User { UserId = 2, FirstName = "Mike", LastName = "Merry", Age = 25, Nationality = "English" },
                    new User { UserId = 3, FirstName = "Pete", LastName = "Pratt", Age = 30, Nationality = "Polish" },
                    new User { UserId = 4, FirstName = "Barry", LastName = "Bowman", Age = 35, Nationality = "South African" },
                    new User { UserId = 5, FirstName = "Luke", LastName = "Letterman", Age = 40, Nationality = "Estonian" }
                };

                repo.Context.Users.AddRange(users);

                repo.Context.SaveChanges();
            }

            return repo;
        }
    }
}
