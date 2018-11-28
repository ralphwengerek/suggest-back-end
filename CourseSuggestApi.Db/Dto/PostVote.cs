using System;
using System.ComponentModel.DataAnnotations;
namespace CourseSuggestApi.Db.Dto
{
    public class PostVote
    {
        public PostVote()
        {
        }

        [Required]
        public int? CourseSuggestionId
        {
            get;
            set;
        }

        [Required]
        public string VoterId
        {
            get;
            set;
        }

        public bool IsValid => this.CourseSuggestionId != 0 && this.VoterId != null;

    }
}

