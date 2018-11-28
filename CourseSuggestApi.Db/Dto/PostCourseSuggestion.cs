using System;
namespace CourseSuggestApi.Db.Dto
{
    public class PostCourseSuggestion
    {
        public PostCourseSuggestion()
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

        public int AbilityLevelId
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

    }
}
