using MediatR;
using Quiz.Application.Common.Exceptions;
using Quiz.Application.Interfaces;
using Quiz.Domain;
using System.Net;

namespace Quiz.Application.Users.Commands.CreateRegisteredUser
{
    public class CreateUserCommandHandler
            : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IQuizDbContext _dbContext;

        public CreateUserCommandHandler(IQuizDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateUserCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                var registeredUser = new User
                {
                    Id = Guid.NewGuid(),
                    Email = request.Email,
                    Name = request.Name,
                    Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                    //Role = "Participant"
                };
                await _dbContext.Users.AddAsync(registeredUser);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return registeredUser.Id;
            }
            catch (Exception)
            {
                throw new UserAlreadyExistsException(request.Email);
            }
        }
    }
}
