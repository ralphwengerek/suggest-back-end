using System;
namespace CourseSuggestApi.Data.Dto
{
    public class PostVote
    {
        public PostVote()
        {
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

