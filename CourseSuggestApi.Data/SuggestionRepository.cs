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

        public CourseSuggestion GetCourseSuggestion(int suggestionId)
        {
            return this.Context.CourseSuggestions
                       .Include(cs => cs.AbilityLevel)
                       .Include(cs => cs.DeliveryMethod)
                       .FirstOrDefault(u => u.CourseSuggestionId == suggestionId);
        }

        public IQueryable<CourseSuggestion> GetCourseSuggestions()
        {
            return this.Context.CourseSuggestions
                       .Include(cs => cs.AbilityLevel)
                       .Include(cs => cs.DeliveryMethod);

        }

        public IQueryable<DeliveryMethod> GetDeliveryMethods()
        {
            return this.Context.DeliveryMethods;
        }

        public IQueryable<AbilityLevel> GetAbilityLevels()
        {
            return this.Context.AbilityLevels;
        }

        public int GetVotesCountForSuggestion(int suggestionId)
        {
            return this.Context.Votes.Where(v => v.CourseSuggestionId == suggestionId).Count();
        }

        public IQueryable<Poll> GetPollSuggestions()
        {
            return this.GetCourseSuggestions()
                            .Select(cs => new Poll
                            {
                                CourseSuggestion = cs,
                                //VoteCount = this.GetVotesCountForSuggestion(cs.CourseSuggestionId)

                            });
        }

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
                CourseSuggestionId = 50, 
             //   AbilityLevel = new AbilityLevel { AbilityLevelId = suggestion.AbilityLevelId}, 
             //   DeliveryMethod = new DeliveryMethod { DeliveryMethodId = suggestion.DeliveryMethodId},
                AuthorLevel = suggestion.AuthorLevel,
                AuthorName = suggestion.AuthorName,
                AuthorRole = suggestion.AuthorRole,
                CourseName = suggestion.CourseName,
                CourseDescription = suggestion.CourseDescription
            };

            courseSuggestion.AbilityLevel = this.Context.AbilityLevels.First();
            courseSuggestion.DeliveryMethod = this.Context.DeliveryMethods.First();

            this.Context.Add(courseSuggestion);
            this.Context.SaveChanges();
        }

        public SuggestDbContext Context { get; }
    }
}
