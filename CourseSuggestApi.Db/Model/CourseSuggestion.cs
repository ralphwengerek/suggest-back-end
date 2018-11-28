using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;


namespace CourseSuggestApi.Db.Model
{
    public class CourseSuggestion 
    {
        public CourseSuggestion()
        {
            this.AbilityLevel = new AbilityLevel();
        }

        [Key]
        public int CourseSuggestionId
        {
            get;
            set;
        }

        public bool IsRunningCourse
        {
            get;
            set;
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

        public AbilityLevel AbilityLevel
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

        public ICollection<Vote> Votes
        {
            get;
            set;
        }

    }
}
