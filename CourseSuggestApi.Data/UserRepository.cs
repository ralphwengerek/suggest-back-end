using System;
using System.Collections.Generic;
using CourseSuggestApi.Data.Model;
using System.Linq;

namespace CourseSuggestApi.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly SuggestDbContext _context;

        public UserRepository(SuggestDbContext context) => this._context = context;

        public User GetUser(int userId)
        {
            return this._context.Users.FirstOrDefault(u => u.UserId == userId);
        }

        public IEnumerable<User> GetUsers()
        {
            return this._context.Users.ToList();
        }

        public SuggestDbContext Context
        {
            get;
            set;
        }
    }
}
