using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quiz.Application.Questions.Commands.CreateQuestion;
using Quiz.Application.Questions.Commands.DeleteQuestion;
using Quiz.Application.Questions.Commands.UpdateQuestion;
using Quiz.Application.Questions.Queries.GetQuestion;
using Quiz.Application.Questions.Queries.GetQuestionList;
using Quiz.WebApi.Models.Questions;

namespace Quiz.WebApi.Controllers
{
    [Authorize]
    [Produces("application/json")]
    //[Authorize(Roles = "Participant")]
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : BaseController
    {
        private readonly IMapper _mapper;

        public QuestionController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets the list of questions
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /question
        /// </remarks>
        /// <returns>Returns QuestionListVm</returns>
        /// <response code = "200">Success</response>
        /// <response code = "401">If the user is unauthorized</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<QuestionListVm>> GetAll()
        {
            var query = new GetQuestionListQuery();
            var vm = await Mediator.Send(query);
            //var userEmail = HttpContext.User.FindFirst(ClaimTypes.Email).Value;

            return Ok(vm);
        }

        /// <summary>
        /// Gets the question by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /question/ 1
        /// </remarks>
        /// <param name="id">Question id(int)</param>
        /// <returns>Returns QuestionVm</returns>
        /// <response code = "200">Success</response>
        /// <response code = "401">If the user is unauthorized</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<QuestionVm>> Get(int id)
        {
            var query = new GetQuestionQuery()
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the question
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST 
        /// {
        ///     title: "question title",
        ///     option1: "some option",
        ///     option2: "right answer",
        ///     option3: "some option",
        ///     option4: "some option",
        ///     answer: "2"
        /// }
        /// </remarks>
        /// <param name="createQuestionDto">CreateQuestionDto object</param>
        /// <returns>Returns id(int)</returns>
        /// <response code = "200">Success</response>
        /// <response code = "401">If the user is unauthorized</response>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<int>> Create([FromBody] CreateQuestionDto createQuestionDto)
        {
            var command = _mapper.Map<CreateQuestionCommand>(createQuestionDto);
            var questionId = await Mediator.Send(command);
            return Ok(questionId);
        }

        /// <summary>
        /// Updates the question by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT 
        /// {
        ///     id:1
        ///     title: "updated question title",
        ///     option1: "updated option",
        ///     option2: "updated answer",
        ///     option3: "updated option",
        ///     option4: "updated option",
        ///     answer: "4"
        /// }
        /// </remarks>
        /// <param name="updateQuestionDto">UpdateQuestionDto object</param>
        /// <returns>Returns NoContent()</returns>
        /// <response code = "200">Success</response>
        /// <response code = "401">If the user is unauthorized</response>

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] UpdateQuestionDto updateQuestionDto)
        {
            var command = _mapper.Map<UpdateQuestionCommand>(updateQuestionDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes the question by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /note/2
        /// </remarks>
        /// <param name="id">Question id (int)</param>
        /// <returns>Returns NoContent()</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteQuestionCommand
            {
                Id = id,
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
