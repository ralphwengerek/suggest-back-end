using System;
using System.Collections.Generic;
using CourseSuggestApi.Db.Dto;
using CourseSuggestApi.Db.Model;
using System.Linq;

namespace CourseSuggestApi.Db
{
    public interface ISuggestionRepository
    {
        IQueryable<CourseSuggestion> GetCourseSuggestions();

        CourseSuggestion GetCourseSuggestion(int userId);
        
        IEnumerable<CourseSuggestionViewModel> GetPollSuggestions();
        IQueryable<AbilityLevel> GetAbilityLevels();

        int GetVotesCountForSuggestion(int suggestionId);

        int Vote(PostVote vote);

        bool CreateCourseSuggestion(PostCourseSuggestion suggestion);

    }
}
