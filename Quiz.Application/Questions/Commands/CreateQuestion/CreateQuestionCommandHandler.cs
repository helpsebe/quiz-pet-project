using MediatR;
using Quiz.Application.Interfaces;
using Quiz.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Questions.Commands.CreateQuestion
{
    public class CreateQuestionCommandHandler 
        :IRequestHandler<CreateQuestionCommand, int>
    {
        private readonly IQuizDbContext _dbContext;
        public CreateQuestionCommandHandler(IQuizDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(CreateQuestionCommand request,
            CancellationToken cancellationToken)
        {
            var qstn = new Question
            {
                Title = request.Title,
                Option1 = request.Option1,
                Option2 = request.Option2,
                Option3 = request.Option3,
                Option4 = request.Option4,
                Answer = request.Answer
            };

            await _dbContext.Questions.AddAsync(qstn);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return qstn.Id;
        }
    }
}
