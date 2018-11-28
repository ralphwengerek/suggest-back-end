using System.ComponentModel.DataAnnotations;

namespace CourseSuggestApi.Data.Model
{
    public class AbilityLevel
    {
        [Key]
        public int AbilityLevelId
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }
    }
}