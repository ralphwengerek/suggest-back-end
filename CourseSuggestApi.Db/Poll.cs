using CourseSuggestApi.Db.Model;

namespace CourseSuggestApi.Db
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