using System;
namespace CourseSuggestApi.Db.Dto
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

