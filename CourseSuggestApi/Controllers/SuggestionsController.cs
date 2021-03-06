﻿using System;
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
        [Route("{voterId}")]
        public IEnumerable<CourseSuggestionViewModel> Get(string voterId)
        {
            return this.repository.GetPollSuggestions(voterId);
        }

        // POST api/suggestions/vote
        [HttpPost]
        [Route("vote")]
        public ActionResult Vote([FromBody]PostVote vote) {
            if (vote.IsValid)
            {
                var result = this.repository.Vote(vote);
                if (result < 0)
                {
                    return this.BadRequest(new ResponseError { ErrorMessage = "You have already voted for this course suggestion.", Code = ResponseError.ErrorCode.AlreadyVoted });
                }
                return this.Ok(new
                {
                    courseSuggestionId = vote.CourseSuggestionId,
                    voteCount = result
                });
            }
            return this.BadRequest(new ResponseError { ErrorMessage = "Invalid post data.", Code = ResponseError.ErrorCode.PostObjectMalformed });

        }

        // POST api/suggestions/vote
        [HttpPost]
        [Route("unvote")]
        public ActionResult UnVote([FromBody]PostVote vote)
        {
            if (vote.IsValid)
            {
                var result = this.repository.UnVote(vote);
                if (result < 0)
                {
                    return this.BadRequest(new ResponseError { ErrorMessage = "You have not voted for this course suggestion yet.", Code = ResponseError.ErrorCode.VoteDoesNotExist });
                }
                return this.Ok(new
                {
                    courseSuggestionId = vote.CourseSuggestionId,
                    voteCount = result
                });
            }
            return this.BadRequest(new ResponseError { ErrorMessage = "Invalid post data.", Code = ResponseError.ErrorCode.PostObjectMalformed });

        }

        [HttpPost]
        public ActionResult CreateSuggestion([FromBody]PostCourseSuggestion suggestion)
        {
            if (this.repository.CreateCourseSuggestion(suggestion))
            {
                return this.Ok(suggestion);
            }
            return this.BadRequest(new ResponseError { ErrorMessage = "Invalid post data.", Code = ResponseError.ErrorCode.PostObjectMalformed });
        }

        [HttpGet]
        [Route("abilitylevels")]
        public IEnumerable<AbilityLevel> GetAbilityLevels()
        {
            return this.repository.GetAbilityLevels();
        }

    }


}

