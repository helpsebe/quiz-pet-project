using MediatR;
using Quiz.Application.Common.Exceptions;
using Quiz.Application.Interfaces;
using Quiz.Domain;

namespace Quiz.Application.Questions.Commands.DeleteQuestion
{
    public class DeleteQuestionCommandHandler
        : IRequestHandler<DeleteQuestionCommand>
    {
        private readonly IQuizDbContext _dbContext;
        public DeleteQuestionCommandHandler(IQuizDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteQuestionCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Questions
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Question), request.Id);
            }

            _dbContext.Questions.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
