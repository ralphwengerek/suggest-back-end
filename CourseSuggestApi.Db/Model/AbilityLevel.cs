using System.ComponentModel.DataAnnotations;

namespace CourseSuggestApi.Db.Model
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