using System;
using System.ComponentModel.DataAnnotations;

namespace CourseSuggestApi.Db.Model
{
    public class Vote
    {
        public Vote()
        {
        }

        [Key]
        public int VoteId
        {
            get;
            set;
        }

        public CourseSuggestion Suggestion
        {
            get;
            set;
        }

        public int CourseSuggestionId
        {
            get;
            set;
        }

        public string VoterId
        {
            get;
            set;
        }
    }
}
