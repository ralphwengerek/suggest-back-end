using System;
using System.ComponentModel.DataAnnotations;

namespace CourseSuggestApi.Db.Dto
{
    public class PostCourseSuggestion
    {
        public PostCourseSuggestion()
        {
        }

        [Required]
        public string CourseName
        {
            get;
            set;
        }

        [Required]
        public string CourseDescription
        {
            get;
            set;
        }

        [Required]
        public int? AbilityLevelId
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

        public bool IsRunningCourse
        {
            get;
            set;
        }

        public bool IsAuthorValid => this.IsRunningCourse &&
                                         this.AuthorName != null &&
                                         this.AuthorRole != null &&
                                         this.AuthorLevel != null;

        public bool IsValid => this.AbilityLevelId != 0 && 
                                   this.CourseName != null &&
                                   this.CourseDescription != null;
    }
}
