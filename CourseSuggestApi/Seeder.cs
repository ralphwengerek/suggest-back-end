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

            Seed(context);
        }

        public static void Seed(SuggestDbContext context){

            if (!context.CourseSuggestions.Any())
            {

                var abilityLevels = new List<AbilityLevel> {
                    new AbilityLevel {
                        Description = "Novice"
                    },
                    new AbilityLevel {
                        Description = "Intermediate"
                    },
                    new AbilityLevel {
                        Description = "Expert"
                    }
                };
                context.AbilityLevels.AddRange(abilityLevels);

                var users = new List<CourseSuggestion>
                {
                    new CourseSuggestion {
                        CourseName = "Course 0",
                        CourseDescription = "This is a course description",
                        AbilityLevel = abilityLevels[0],
                        AuthorLevel = "",
                        AuthorName = "John Doe",
                        AuthorRole = ""
                    },
                    new CourseSuggestion {
                        CourseName = "Course 1",
                        CourseDescription = "This is a course description",
                        AbilityLevel = abilityLevels[0],
                        AuthorLevel = "",
                        AuthorName = "Olga Ivanova",
                        AuthorRole = ""
                    },
                    new CourseSuggestion {
                        CourseName = "Course 2",
                        CourseDescription = "This is a course description",
                        AbilityLevel = abilityLevels[0],
                        AuthorLevel = "",
                        AuthorName = "Pete Pratt",
                        AuthorRole = ""
                    }
                };

                context.CourseSuggestions.AddRange(users);

                context.SaveChanges();


            }
        }
    }
}


