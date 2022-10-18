using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Quiz.Application.Questions.Commands.DeleteQuestion;
using Quiz.Application.Questions.Commands.UpdateQuestion;
using Quiz.Application.Questions.Queries.GetQuestion;
using Quiz.Application.Questions.Queries.GetQuestionList;
using Quiz.WebApi.Models;

namespace Quiz.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class QuestionController : BaseController
    {
        private readonly IMapper _mapper;

        public QuestionController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<QuestionListVm>> GetAll()
        {
            var query = new GetQuestionListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionVm>> Get(int id)
        {
            var query = new GetQuestionQuery()
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateQuestionDto createQuestionDto)
        {
            var command = _mapper.Map<CreateQuestionDto>(createQuestionDto);
            var questionId = await Mediator.Send(command);
            return Ok(questionId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateQuestionDto updateQuestionDto)
        {
            var command = _mapper.Map<UpdateQuestionCommand>(updateQuestionDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
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
