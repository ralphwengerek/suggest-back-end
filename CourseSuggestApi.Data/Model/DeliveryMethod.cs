using System.ComponentModel.DataAnnotations;

namespace CourseSuggestApi.Data.Model
{
    public class DeliveryMethod
    {
        [Key]
        public int DeliveryMethodId
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