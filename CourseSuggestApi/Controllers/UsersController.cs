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
        private readonly IUserRepository repository;

        public UsersController(IUserRepository repository) => this.repository = repository;

        // GET api/users
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return this.repository.GetUsers();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return this.repository.GetUser(id);
        }

    }
}

