using System;
namespace CourseSuggestApi.Db.Dto
{
    public class CourseSuggestionViewModel
    {
        public CourseSuggestionViewModel()
        {

        }

        public string CourseName
        {
            get;
            set;
        }

        public string CourseDescription
        {
            get;
            set;
        }

        public int CourseSuggestionId
        {
            get;
            set;
        }

        public string AbilityLevelDescription
        {
            get;
            set;
        }

        public string AuthorName
        {
            get;
            set;
        }

        public string AuthorRole
        {
            get;
            set;
        }

        public string AuthorLevel
        {
            get;
            set;
        }

        public int VoteCount
        {
            get;
            set;
        }

        public bool HasVoted
        {
            get;
            set;
        }
    }
}
