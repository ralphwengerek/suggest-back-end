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
                         DeliveryMethodId = 1,
                        Description = "Workshop"
                    },
                    new DeliveryMethod {
                         DeliveryMethodId = 2,
                        Description = "Online"
                    }
                };

                context.DeliveryMethods.AddRange(deliveryMethods);

                var abilityLevels = new List<AbilityLevel> {
                    new AbilityLevel {
                        AbilityLevelId = 1,
                        Description = "Novice"
                    },
                    new AbilityLevel {
                        AbilityLevelId = 2,
                        Description = "Intermediate"
                    },
                    new AbilityLevel {
                        AbilityLevelId = 3,
                        Description = "Expert"
                    }
                };
                context.AbilityLevels.AddRange(abilityLevels);

                var users = new List<CourseSuggestion>
                {
                    new CourseSuggestion {
                        CourseSuggestionId = 1, 
                        CourseName = "Course 0",
                        CourseDescription = "", 
                        AbilityLevel = abilityLevels[0],
                        DeliveryMethod = deliveryMethods[0],
                        AuthorLevel = "",
                        AuthorName = "John Doe",
                        AuthorRole = ""
                    },
                    new CourseSuggestion {
                        CourseSuggestionId = 2,
                        CourseName = "Course 1",
                        CourseDescription = "",
                        AbilityLevel = abilityLevels[0],
                        DeliveryMethod = deliveryMethods[0],
                        AuthorLevel = "",
                        AuthorName = "Olga Ivanova",
                        AuthorRole = ""
                    },
                    new CourseSuggestion { 
                        CourseSuggestionId = 3, 
                        CourseName = "Course 2", 
                        CourseDescription = "",
                        AbilityLevel = abilityLevels[0],
                        DeliveryMethod = deliveryMethods[0],
                        AuthorLevel = "",
                        AuthorName = "Pete Pratt",
                        AuthorRole = ""
                    },
                    new CourseSuggestion { 
                        CourseSuggestionId = 4,
                        CourseName = "Course 3",
                        CourseDescription = "",
                        AbilityLevel = abilityLevels[0],
                        DeliveryMethod = deliveryMethods[0],
                        AuthorLevel = "",
                        AuthorName = "Barry Bowman",
                        AuthorRole = ""
                    },
                    new CourseSuggestion { 
                        CourseSuggestionId = 5,
                        CourseName = "Course 4",
                        CourseDescription = "",
                        AbilityLevel = abilityLevels[0],
                        DeliveryMethod = deliveryMethods[0],
                        AuthorLevel = "",
                        AuthorName = "Ella Smithe",
                        AuthorRole = ""
                    },
                    new CourseSuggestion { 
                        CourseSuggestionId = 6,
                        CourseName = "Course 5",
                        CourseDescription = "",
                        AbilityLevel = abilityLevels[0],
                        DeliveryMethod = deliveryMethods[0],
                        AuthorLevel = "",
                        AuthorName = "Lyla Fibert",
                        AuthorRole = ""
                    },
                    new CourseSuggestion {
                        CourseSuggestionId = 7,
                        CourseName = "Course 6",
                        CourseDescription = "",
                        AbilityLevel = abilityLevels[0],
                        DeliveryMethod = deliveryMethods[0],
                        AuthorLevel = "",
                        AuthorName = "Luke Letterman",
                        AuthorRole = ""
                    }
                };

                context.CourseSuggestions.AddRange(users);

                context.SaveChanges();


            }
        }
    }
}


