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
        private readonly ISuggestionRepository repository;

        public UsersController(ISuggestionRepository repository) => this.repository = repository;

        // GET api/users
        [HttpGet]
        public IEnumerable<Poll> Get()
        {
            return this.repository.GetPollSuggestions();
        }

        public ActionResult Vote(int suggestionId, string voterId) {

            this.repository.Vote(suggestionId, voterId);

            return Ok();
        }
    }
}

