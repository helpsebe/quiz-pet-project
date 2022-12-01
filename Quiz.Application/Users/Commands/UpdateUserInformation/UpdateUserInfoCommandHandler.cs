using MediatR;
using Microsoft.EntityFrameworkCore;
using Quiz.Application.Common.Exceptions;
using Quiz.Application.Interfaces;
using Quiz.Domain;

namespace Quiz.Application.Users.Commands.UpdateUser
{
    public class UpdateUserInfoCommandHandler 
        : IRequestHandler<UpdateUserInformationCommand>
    {
        private readonly IQuizDbContext _dbContext;
        public UpdateUserInfoCommandHandler(IQuizDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateUserInformationCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u =>
            u.Id == request.Id, cancellationToken);

            if (user == null || user.Id != request.Id)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            user.Email = request.Email;
            user.Name = request.Name;
            user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
