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

        [Required]
        public string AuthorName
        {
            get;
            set;
        }

        [Required]
        public string AuthorRole
        {
            get;
            set;
        }

        [Required]
        public string AuthorLevel
        {
            get;
            set;
        }

        public bool IsValid => this.AbilityLevelId != 0 && 
                                   this.CourseName != null &&
                                   this.CourseDescription != null && 
                                   this.AuthorName != null &&
                                   this.AuthorRole != null && 
                                   this.AuthorLevel != null;
    }
}
