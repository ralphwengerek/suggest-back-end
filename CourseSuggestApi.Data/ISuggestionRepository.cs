using System;
using System.Collections.Generic;
using CourseSuggestApi.Data.Dto;
using CourseSuggestApi.Data.Model;
using System.Linq;

namespace CourseSuggestApi.Data
{
    public interface ISuggestionRepository
    {
        IQueryable<CourseSuggestion> GetCourseSuggestions();

        CourseSuggestion GetCourseSuggestion(int userId);
        
        IEnumerable<CourseSuggestionViewModel> GetPollSuggestions();
        IQueryable<AbilityLevel> GetAbilityLevels();
        IQueryable<DeliveryMethod> GetDeliveryMethods();

        int GetVotesCountForSuggestion(int suggestionId);

        int Vote(PostVote vote);

        void CreateCourseSuggestion(PostCourseSuggestion suggestion);

    }
}
