using MediatR;
using Microsoft.EntityFrameworkCore;
using Quiz.Application.Common.Exceptions;
using Quiz.Application.Interfaces;
using Quiz.Domain;

namespace Quiz.Application.Questions.Commands.UpdateQuestion
{
    public class UpdateQuestionCommandHandler 
        :IRequestHandler<UpdateQuestionCommand>
    {
        private readonly IQuizDbContext _dbContext;
        public UpdateQuestionCommandHandler(IQuizDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateQuestionCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Questions.FirstOrDefaultAsync(qstn =>
                    qstn.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Question), request.Id);
            }

            entity.Title = request.Title;
            entity.Option1 = request.Option1;
            entity.Option2 = request.Option2;
            entity.Option3 = request.Option3;
            entity.Option4 = request.Option4;
            entity.Answer = request.Answer;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}
