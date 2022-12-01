using MediatR;
using Quiz.Application.Common.Exceptions;
using Quiz.Application.Interfaces;
using Quiz.Application.Questions.Commands.DeleteQuestion;
using Quiz.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Users.Commands.DeteleUser
{
    public class DeleteUserCommandHandler
        :IRequestHandler<DeleteUserCommand>
    {
        private readonly IQuizDbContext _dbContext;
        public DeleteUserCommandHandler(IQuizDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteUserCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (user == null || user.Id != request.Id)
            {
                throw new NotFoundException(nameof(Question), request.Id);
            }

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
