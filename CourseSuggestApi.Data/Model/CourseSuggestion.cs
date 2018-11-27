using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;


namespace CourseSuggestApi.Data.Model
{
    public class CourseSuggestion 
    {
        public CourseSuggestion()
        {
            this.DeliveryMethod = new DeliveryMethod();
            this.AbilityLevel = new AbilityLevel();
        }

        [Key]
        public int CourseSuggestionId
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

        public DeliveryMethod DeliveryMethod
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
