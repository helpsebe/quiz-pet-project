using MediatR;
using Microsoft.EntityFrameworkCore;
using Quiz.Application.Common.Exceptions;
using Quiz.Application.Interfaces;
using Quiz.Domain;

namespace Quiz.Application.Users.Commands.UpdateUserScore
{
    public class UpdateUserScoreCommandHandler
        : IRequestHandler<UpdateUserScoreCommand>
    {
        private readonly IQuizDbContext _dbContext;
        public UpdateUserScoreCommandHandler(IQuizDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateUserScoreCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u =>
            u.Id == request.Id, cancellationToken);

            if (user == null || user.Id != request.Id)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            user.Score = request.Score;
            user.TimeTaken = request.TimeTaken;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
