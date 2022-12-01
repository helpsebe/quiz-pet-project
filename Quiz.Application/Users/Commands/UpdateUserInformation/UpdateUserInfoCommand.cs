using MediatR;

namespace Quiz.Application.Users.Commands.UpdateUser
{
    public class UpdateUserInformationCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}
