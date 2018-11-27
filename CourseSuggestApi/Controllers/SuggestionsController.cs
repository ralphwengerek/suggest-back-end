using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseSuggestApi.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using CourseSuggestApi.Data.Model;
using System.Data;
using CourseSuggestApi.Data.Dto;

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
        public IEnumerable<Poll> Get()
        {
            return this.repository.GetPollSuggestions();
        }

        // POST api/suggestions/vote
        [HttpPost]
        [Route("vote")]
        public ActionResult Vote([FromBody]PostVote vote) {

            this.repository.Vote(vote);

            return Ok();
        }

        [HttpPost]
        public ActionResult CreateSuggestion([FromBody]PostCourseSuggestion suggestion)
        {
            this.repository.CreateCourseSuggestion(suggestion);

            return Ok();
        }

        [HttpGet]
        [Route("deliverymethods")]
        public IEnumerable<DeliveryMethod> GetDeliveryMethods()
        {
            return this.repository.GetDeliveryMethods();
        }

        [HttpGet]
        [Route("abilitylevels")]
        public IEnumerable<AbilityLevel> GetAbilityLevels()
        {
            return this.repository.GetAbilityLevels();
        }
    }


}

