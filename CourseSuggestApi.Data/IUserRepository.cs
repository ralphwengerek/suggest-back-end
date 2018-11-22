using System;
using System.Collections.Generic;
using CourseSuggestApi.Data.Model;

namespace CourseSuggestApi.Data
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();

        User GetUser(int userId);


    }
}
