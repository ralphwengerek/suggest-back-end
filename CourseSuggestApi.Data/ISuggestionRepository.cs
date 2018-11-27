using System;
using System.Collections.Generic;
using CourseSuggestApi.Data.Dto;
using CourseSuggestApi.Data.Model;

namespace CourseSuggestApi.Data
{
    public interface ISuggestionRepository
    {
        IEnumerable<CourseSuggestion> GetCourseSuggestions();

        CourseSuggestion GetCourseSuggestion(int userId);
        
        IEnumerable<Poll> GetPollSuggestions();
        IEnumerable<AbilityLevel> GetAbilityLevels();
        IEnumerable<DeliveryMethod> GetDeliveryMethods();

        int GetVotesCountForSuggestion(int suggestionId);

        Vote Vote(PostVote vote);

        void CreateCourseSuggestion(PostCourseSuggestion suggestion);

    }
}
