using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CourseSuggestApi.Db.Model;
using System.Linq;
using System;
using CourseSuggestApi.Db.Dto;

namespace CourseSuggestApi.Db
{
    public class SuggestionRepository : ISuggestionRepository
    {
        public SuggestionRepository(SuggestDbContext context) => this.Context = context;

        public CourseSuggestion GetCourseSuggestion(int suggestionId) => this.Context.CourseSuggestions
                       .Include(cs => cs.AbilityLevel)
                       .FirstOrDefault(u => u.CourseSuggestionId == suggestionId);

        public IQueryable<CourseSuggestion> GetCourseSuggestions() => this.Context.CourseSuggestions
                       .Include(cs => cs.AbilityLevel);
                       
        public IQueryable<AbilityLevel> GetAbilityLevels() => this.Context.AbilityLevels;

        public int GetVotesCountForSuggestion(int suggestionId) => this.Context.Votes.Where(v => v.CourseSuggestionId == suggestionId).Count();

        public IEnumerable<CourseSuggestionViewModel> GetPollSuggestions(string voterId) {
            var models = this.GetCourseSuggestions()
                            .Select(cs => new CourseSuggestionViewModel
                            {
                                AbilityLevelDescription = cs.AbilityLevel.Description,
                                VoteCount = cs.Votes.Count,
                                AuthorLevel = cs.AuthorLevel,
                                AuthorRole = cs.AuthorRole,
                                AuthorName = cs.AuthorName,
                                CourseDescription = cs.CourseDescription,
                                CourseName = cs.CourseName,
                                CourseSuggestionId = cs.CourseSuggestionId,
                                HasVoted = cs.Votes.Any((arg) => arg.VoterId == voterId)
                            }).ToList();

            return models;
        } 

        public int Vote(PostVote postVote)
        {
            var votesForSuggestion = this.Context.Votes.Where((arg) => arg.CourseSuggestionId == postVote.CourseSuggestionId).ToList();
            var votesNumber = votesForSuggestion.Count((arg) => arg.VoterId == postVote.VoterId);
            if (votesNumber > 0)
            {
                return (int)ResponseError.ErrorCode.AlreadyVoted;
            }

            var vote = new Vote
            {
                CourseSuggestionId = postVote.CourseSuggestionId.Value,
                VoterId = postVote.VoterId
            };
            this.Context.Votes.Add(vote);
            this.Context.SaveChanges();
            return GetVotesCountForSuggestion(postVote.CourseSuggestionId.Value);
        }

       
        public bool CreateCourseSuggestion(PostCourseSuggestion suggestion)
        {
            if (suggestion.IsRunningCourse) 
            {
                if (!suggestion.IsAuthorValid)
                {
                    return false;
                }
            }

            var courseSuggestion = new CourseSuggestion
            {
                CourseName = suggestion.CourseName,
                CourseDescription = suggestion.CourseDescription,

                IsRunningCourse = suggestion.IsRunningCourse,
                AuthorLevel = suggestion.AuthorLevel,
                AuthorName = suggestion.AuthorName,
                AuthorRole = suggestion.AuthorRole
            };
            courseSuggestion.AbilityLevel = this.Context.AbilityLevels.Find(suggestion.AbilityLevelId);
            this.Context.Add(courseSuggestion);
            this.Context.SaveChanges();
            return true;
        }

        public SuggestDbContext Context { get; }
    }
}
