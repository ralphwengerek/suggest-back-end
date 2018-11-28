using System;
using System.Collections.Generic;
using CourseSuggestApi.Db;
using CourseSuggestApi.Db.Dto;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Linq;

namespace CourseSuggestApi.Tests
{
    public class SuggestRepositoryTests
    {

        private ISuggestionRepository GetInMemoryUserRepository()
        {
            var options = new DbContextOptionsBuilder<SuggestDbContext>()
                .UseInMemoryDatabase(databaseName: "SuggestDatabase")
                .Options;

            var suggestDbContext = new SuggestDbContext(options);
            suggestDbContext.Database.EnsureDeleted();
            suggestDbContext.Database.EnsureCreated();


            Seeder.Seed(suggestDbContext);


            var repo = new SuggestionRepository(suggestDbContext);

            return repo;
        }

        [Fact]
        private void GetCourseSuggestionsTest()
        {
            var repo = GetInMemoryUserRepository();
            var suggestions = repo.GetPollSuggestions().ToList();
            Assert.True(suggestions.Count > 0);
        }

        [Fact]
        private void AddNewSuggestionTest()
        {
            var repo = GetInMemoryUserRepository();
            var suggestions = repo.GetPollSuggestions().ToList();
            var currentNumber = suggestions.Count();

            var postSuggestion = new PostCourseSuggestion
            {
                AbilityLevelId = 1,
                AuthorLevel = "Level 90",
                AuthorName = "John Smith",
                AuthorRole = "Blacksmith",
                CourseDescription = "Smithing fundamentals",
                CourseName = "Smithing"
            };

            repo.CreateCourseSuggestion(postSuggestion);

            Assert.Equal(currentNumber + 1, repo.GetPollSuggestions().Count());
        }
        [Fact]
        private void VoteTest() {
            var repo = GetInMemoryUserRepository();
            var suggestions = repo.GetPollSuggestions().ToList();
            var poll = suggestions[2];
            var poll2 = suggestions[3];
            var id = poll.CourseSuggestionId;
            var id2 = poll2.CourseSuggestionId;
            var postVote = new PostVote { CourseSuggestionId = id, VoterId = "Bob" };
            var postVote2 = new PostVote { CourseSuggestionId = id, VoterId = "Alex" };
            var postVote3 = new PostVote { CourseSuggestionId = id2, VoterId = "Alex" };
            repo.Vote(postVote);
            repo.Vote(postVote2);
            repo.Vote(postVote3);

            Assert.Equal(2, repo.GetPollSuggestions().ToList().First((arg) => arg.CourseSuggestionId == id).VoteCount);
            Assert.Equal(1, repo.GetPollSuggestions().ToList().First((arg) => arg.CourseSuggestionId == id2).VoteCount);
        }

        [Fact]
        private void VoteForTheSameSuggestionTest()
        {
            var repo = GetInMemoryUserRepository();
            var suggestions = repo.GetPollSuggestions().ToList();
            var poll = suggestions[2];
            var id = poll.CourseSuggestionId;
            var postVote = new PostVote { CourseSuggestionId = id, VoterId = "Bob" };
            var postVote2 = new PostVote { CourseSuggestionId = id, VoterId = "Bob" };

            Assert.Equal(1, repo.Vote(postVote));
            Assert.Equal(1, repo.GetPollSuggestions().ToList().First((arg) => arg.CourseSuggestionId == id).VoteCount);
            Assert.Equal(-1, repo.Vote(postVote2));

        }
    }
}
