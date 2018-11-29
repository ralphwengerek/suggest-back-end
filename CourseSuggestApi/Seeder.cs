using System;
using CourseSuggestApi.Db;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Collections.Generic;
using CourseSuggestApi.Db.Model;

namespace CourseSuggestApi
{
    public static class Seeder
    {
        public static void SeedDatabase(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<SuggestDbContext>();

            Seed(context);
        }

        public static void Seed(SuggestDbContext context)
        {

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
                        CourseName = "The Web Developer Bootcamp",
                        CourseDescription = $@"The only course you need to learn web development - HTML, CSS, JS, Node, and More!
                        Make REAL web applications using cutting-edge technologies
                        Continue to learn and grow as a developer, long after the course ends
                        Create a blog application from scratch using Express, MongoDB, and Semantic UI
                        Create a complicated yelp-like application from scratch",
                        AbilityLevel = abilityLevels[0],
                        AuthorLevel = "Level 1",
                        AuthorName = "John Doe",
                        AuthorRole = "Product Analyst"
                    },
                    new CourseSuggestion {
                        CourseName = "Machine Learning A-Z™: Hands-On Python & R In Data Science",
                        CourseDescription = $@"Learn to create Machine Learning Algorithms in Python and R from two Data Science experts. Code templates included.
                        Master Machine Learning on Python & R
                        Have a great intuition of many Machine Learning models
                        Make accurate predictions
                        Make powerful analysis
                        Make robust Machine Learning models",
                        AbilityLevel = abilityLevels[0],
                        AuthorLevel = "Level 4",
                        AuthorName = "Olga Ivanova",
                        AuthorRole = "Product Developer"
                    },
                    new CourseSuggestion {
                        CourseName = "The Complete JavaScript Course 2018: Build Real Projects!",
                        CourseDescription = $@"Master JavaScript with the most complete course on the market! Projects, challenges, quizzes, ES6+, OOP, AJAX, Webpack
                        Go from a total beginner to an advanced JavaScript developer
                        Code 3 beautiful real-world apps with both ES5 and ES6+ (no boring toy apps)
                        JavaScript and programming fundamentals: variables, boolean logic, if/else, loops, functions, arrays, etc.
                        Complex features like the 'this' keyword, function constructors, prototypal inheritance, first-class functions, closures",
                        AbilityLevel = abilityLevels[0],
                        AuthorLevel = "Level 3",
                        AuthorName = "Pete Pratt",
                        AuthorRole = "Product Developer"
                    },
                    new CourseSuggestion {
                        CourseName = "The Complete Node.js Developer Course!",
                        CourseDescription = $@"Learn Node.js by building real-world applications with Node, Express, MongoDB, Mocha, and more!
                        Build, test, and launch Node apps
                        Create Express web servers and APIs
                        Store data with Mongoose and MongoDB
                        Use cutting-edge ES6/ES7 JavaScript
                        Deploy your Node apps to production
                        ",
                        AbilityLevel = abilityLevels[0],
                        AuthorLevel = "Level 5",
                        AuthorName = "Barry Bowman",
                        AuthorRole = "Product Developer"
                    },
                };

                context.CourseSuggestions.AddRange(users);

                context.SaveChanges();


            }
        }
    }
}
