using System;
using System.Data;

namespace CourseSuggestApi.Data.Model
{
    public class User 
    {
        public User()
        {
        }

        public int UserId
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string Nationality
        {
            get;
            set;
        }

        public int Age
        {
            get;
            set;
        }

    }
}
