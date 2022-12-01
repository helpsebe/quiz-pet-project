using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quiz.Application.Users.Commands.CreateRegisteredUser;
using Quiz.Application.Users.Queries.GetUser;
using Quiz.WebApi.Helpers.Services.Interfaces;
using Quiz.WebApi.Models.Users;

namespace Quiz.WebApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;
        public AuthController(IConfiguration configuration, IMapper mapper, IJwtService jwtService) =>
            (_configuration, _mapper, _jwtService) = (configuration, mapper, jwtService);

        /// <summary>
        /// Creates the user
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST 
        /// {
        ///     name: "Gustav",
        ///     email: "test@gmail.com",
        ///     password: "password",
        /// }
        /// </remarks>
        /// <param name="registerUserDto">UserRegisterDto object</param>
        /// <returns>Returns id(Guid)</returns>
        /// <response code = "200">Success</response>
        /// <response code = "409">User with this email already exists/response>
        [HttpPost(Name = (nameof(Register)))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<Guid>> Register([FromBody] UserRegisterDto userRegisterDto)
        {
            var user = _mapper.Map<CreateUserCommand>(userRegisterDto);
            var userId = await Mediator.Send(user);
            return Ok(userId);
        }

        /// <summary>
        /// Authenticate the user. Provides with unique JWT token
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST 
        /// {
        ///     email: "test@gmail.com",
        ///     password: "password",
        /// }
        /// </remarks>
        /// <param name="userLoginDto">UserLoginDto object</param>
        /// <returns>Returns JWT token(string)</returns>
        /// <response code = "200">Success</response>
        /// <response code = "400">Invalid Credentials</response>
        [HttpPost(Name = (nameof(Login)))]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            var query = new GetUserByEmailQuery()
            {
                Email = userLoginDto.Email,
            };

            var user = await Mediator.Send(query);

            if (user == null) return BadRequest(new { message = "Invalid Credentials" });

            if (!BCrypt.Net.BCrypt.Verify(userLoginDto.Password, user.Password))
            {
                return BadRequest(new { message = "Invalid Credentials" });
            }
            var token = _jwtService.Generate(user);

            Response.Cookies.Append("jwt", token, new CookieOptions
            {
                HttpOnly = true
            });

            return Ok(token);
        }

        /// <summary>
        /// Logout. Deletes cookie from the browser
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST/ auth/ logout
        /// </remarks>
        /// <returns>Returns success message</returns>
        /// <response code = "200">Success</response>
        /// <response code = "400">Bad Request</response>
        [HttpPost]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");

            return Ok(new
            {
                message = "success"
            });
        }

        //[HttpGet]
        //public IActionResult ValidateToken()
        //{
        //    try
        //    {
        //        var jwt = Request.Cookies["jwt"];

        //        var token = _jwtService.Verify(jwt);
        //        //var user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;


        //        return Ok();
        //        //return Ok();
        //    }
        //    catch (Exception)
        //    {
        //        return Unauthorized();
        //    }
        // }
    }
}