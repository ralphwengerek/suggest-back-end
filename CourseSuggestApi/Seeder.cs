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

            if (!context.CourseSuggestions.Any())
            {

                var deliveryMethods = new List<DeliveryMethod> {
                    new DeliveryMethod {
                        Description = "Workshop"
                    },
                    new DeliveryMethod {
                        Description = "Online"
                    }
                };

                context.DeliveryMethods.AddRange(deliveryMethods);

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
                        DeliveryMethod = deliveryMethods[0],
                        AuthorLevel = "",
                        AuthorName = "John Doe",
                        AuthorRole = ""
                    },
                    new CourseSuggestion {
                        CourseName = "Course 1",
                        CourseDescription = "This is a course description",
                        AbilityLevel = abilityLevels[0],
                        DeliveryMethod = deliveryMethods[0],
                        AuthorLevel = "",
                        AuthorName = "Olga Ivanova",
                        AuthorRole = ""
                    },
                    new CourseSuggestion { 
                        CourseName = "Course 2", 
                        CourseDescription = "This is a course description",
                        AbilityLevel = abilityLevels[0],
                        DeliveryMethod = deliveryMethods[0],
                        AuthorLevel = "",
                        AuthorName = "Pete Pratt",
                        AuthorRole = ""
                    },
                    new CourseSuggestion { 
                        CourseName = "Course 3",
                        CourseDescription = "This is a course description",
                        AbilityLevel = abilityLevels[0],
                        DeliveryMethod = deliveryMethods[0],
                        AuthorLevel = "",
                        AuthorName = "Barry Bowman",
                        AuthorRole = ""
                    },
                    new CourseSuggestion { 
                        CourseName = "Course 4",
                        CourseDescription = "This is a course description",
                        AbilityLevel = abilityLevels[0],
                        DeliveryMethod = deliveryMethods[0],
                        AuthorLevel = "",
                        AuthorName = "Ella Smithe",
                        AuthorRole = ""
                    },
                };

                context.CourseSuggestions.AddRange(users);

                context.SaveChanges();


            }
        }
    }
}


