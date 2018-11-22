using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseSuggestApi.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using CourseSuggestApi.Data.Model;
using System.Data;

namespace CourseSuggestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private SuggestDbContext _context;

        public UsersController(SuggestDbContext context){
            _context = context;
        }
        // GET api/users
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return _context.Users.ToList();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = _context.Users.Where(u => u.UserId == id).First();

            return user;
        }

    }
}

