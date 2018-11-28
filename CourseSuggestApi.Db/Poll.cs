using CourseSuggestApi.Data.Model;

namespace CourseSuggestApi.Data
{
    public class Poll
    {
        public CourseSuggestion CourseSuggestion
        {
            get;
            set;
        }

        public int VoteCount
        {
            get;
            set;
        }
    }
}