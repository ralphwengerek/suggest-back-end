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


        //private ISuggestionRepository GetInMemoryUserRepository()
        //{
        //    var options = new DbContextOptionsBuilder<SuggestDbContext>()
        //        .UseInMemoryDatabase(databaseName: "SuggestDatabase")
        //        .Options;

        //    var suggestDbContext = new SuggestDbContext(options);
        //    suggestDbContext.Database.EnsureDeleted();
        //    suggestDbContext.Database.EnsureCreated();

        //    var repo = new UserRepository(suggestDbContext);

        //    if (!repo.Context.Users.Any())
        //    {
        //        var users = new List<CourseSuggestion>
        //        {
        //            new CourseSuggestion { CourseSuggestionId = 1, CourseName = "John", CourseDescription = "Doe", Age = 20, DeliveryMethod = "German" },
        //            new CourseSuggestion { CourseSuggestionId = 2, CourseName = "Mike", CourseDescription = "Merry", Age = 25, DeliveryMethod = "English" },
        //            new CourseSuggestion { CourseSuggestionId = 3, CourseName = "Pete", CourseDescription = "Pratt", Age = 30, DeliveryMethod = "Polish" },
        //            new CourseSuggestion { CourseSuggestionId = 4, CourseName = "Barry", CourseDescription = "Bowman", Age = 35, DeliveryMethod = "South African" },
        //            new CourseSuggestion { CourseSuggestionId = 5, CourseName = "Luke", CourseDescription = "Letterman", Age = 40, DeliveryMethod = "Estonian" }
        //        };

        //        repo.Context.Users.AddRange(users);

        //        repo.Context.SaveChanges();
        //    }

        //    return repo;
        //}
    }
}
