using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseSuggestApi.Db;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using CourseSuggestApi.Db.Model;
using System.Data;
using CourseSuggestApi.Db.Dto;

namespace CourseSuggestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuggestionsController : ControllerBase
    {
        private readonly ISuggestionRepository repository;

        public SuggestionsController(ISuggestionRepository repository) => this.repository = repository;

        // GET api/suggestions
        [HttpGet]
        public IEnumerable<CourseSuggestionViewModel> Get()
        {
            return this.repository.GetPollSuggestions();
        }

        // POST api/suggestions/vote
        [HttpPost]
        [Route("vote")]
        public ActionResult Vote([FromBody]PostVote vote) {

            var result = this.repository.Vote(vote);
            if (result == (int)( ResponseError.ErrorCode.AlreadyVoted)) {
                return BadRequest(new ResponseError { ErrorMessage = "You have already voted for this course suggestion.", Code = ResponseError.ErrorCode.AlreadyVoted});
            }
            return Ok(new {
                courseSuggestionId = vote.CourseSuggestionId,
                voteCount = result
            });
        }

        [HttpPost]
        public ActionResult CreateSuggestion([FromBody]PostCourseSuggestion suggestion)
        {
            this.repository.CreateCourseSuggestion(suggestion);

            return Ok();
        }

        [HttpGet]
        [Route("abilitylevels")]
        public IEnumerable<AbilityLevel> GetAbilityLevels()
        {
            return this.repository.GetAbilityLevels();
        }

    }


}

