using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CourseSuggestApi.Data.Model;
using System.Linq;
using System;
using CourseSuggestApi.Data.Dto;

namespace CourseSuggestApi.Data
{
    public class SuggestionRepository : ISuggestionRepository
    {
        public SuggestionRepository(SuggestDbContext context) => this.Context = context;

        public CourseSuggestion GetCourseSuggestion(int suggestionId) => this.Context.CourseSuggestions
                       .Include(cs => cs.AbilityLevel)
                       .Include(cs => cs.DeliveryMethod)
                       .FirstOrDefault(u => u.CourseSuggestionId == suggestionId);

        public IQueryable<CourseSuggestion> GetCourseSuggestions() => this.Context.CourseSuggestions
                       .Include(cs => cs.AbilityLevel)
                       .Include(cs => cs.DeliveryMethod);

        public IQueryable<DeliveryMethod> GetDeliveryMethods() => this.Context.DeliveryMethods;

        public IQueryable<AbilityLevel> GetAbilityLevels() => this.Context.AbilityLevels;

        public int GetVotesCountForSuggestion(int suggestionId) => this.Context.Votes.Where(v => v.CourseSuggestionId == suggestionId).Count();

        public IQueryable<Poll> GetPollSuggestions() => this.GetCourseSuggestions()
                            .Select(cs => new Poll
                            {
                                CourseSuggestion = cs,
                                VoteCount = cs.Votes.Count

                            });

        public Vote Vote(PostVote postVote)
        {
            var vote = new Vote
            {
                CourseSuggestionId = postVote.CourseSuggestionId,
                VoterId = postVote.VoterId
            };
            this.Context.Votes.Add(vote);
            this.Context.SaveChanges();

            return vote;
        }

       
        public void CreateCourseSuggestion(PostCourseSuggestion suggestion)
        {

            var a = this.Context.AbilityLevels.First();

            var courseSuggestion = new CourseSuggestion
            {
                AuthorLevel = suggestion.AuthorLevel,
                AuthorName = suggestion.AuthorName,
                AuthorRole = suggestion.AuthorRole,
                CourseName = suggestion.CourseName,
                CourseDescription = suggestion.CourseDescription
            };

            courseSuggestion.AbilityLevel = this.Context.AbilityLevels.Find(suggestion.AbilityLevelId);
            courseSuggestion.DeliveryMethod = this.Context.DeliveryMethods.Find(suggestion.DeliveryMethodId);

            this.Context.Add(courseSuggestion);
            this.Context.SaveChanges();
        }

        public SuggestDbContext Context { get; }
    }
}
