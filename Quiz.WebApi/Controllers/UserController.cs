using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quiz.Application.Users.Commands.DeteleUser;
using Quiz.Application.Users.Commands.UpdateUser;
using Quiz.Application.Users.Commands.UpdateUserScore;
using Quiz.Application.Users.Queries.GetUser;
using Quiz.Application.Users.Queries.GetUserById;
using Quiz.WebApi.Helpers.Services.Interfaces;
using Quiz.WebApi.Models.Users;

namespace Quiz.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]
    //[Authorize(Roles = "Participant")]
    public class UserController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;
        public UserController(IConfiguration configuration, IMapper mapper, IJwtService jwtService) =>
            (_configuration, _mapper, _jwtService) = (configuration, mapper, jwtService);

        [HttpGet]
        public async Task<ActionResult<UserVm>> GetByEmail(string email)
        {
            var query = new GetUserByEmailQuery()
            {
                Email = email
            };
            var user = await Mediator.Send(query);

            return Ok(user);
        }

        [HttpGet("id")]
        public async Task<ActionResult<UserVm>> GetById(Guid id)
        {
            var query = new GetUserByIdQuery()
            {
                Id = id
            };
            var user = await Mediator.Send(query);

            return Ok(user);
        }

        [HttpPut(Name = nameof(UpdateInformation))]
        public async Task<IActionResult> UpdateInformation([FromBody] UpdateUserInfoDto updateUserDto)
        {
            //updateUserDto.Id = Guid.Parse(HttpContext.User.FindFirst("Id").Value);
            var command = _mapper.Map<UpdateUserInformationCommand>(updateUserDto);
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut(Name = nameof(UpdateScore))]
        public async Task<IActionResult> UpdateScore([FromBody] UpdateUserScoreDto updateUserDto)
        {
            var command = _mapper.Map<UpdateUserScoreCommand>(updateUserDto);
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete(Name = nameof(Delete))]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteUserCommand()
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
