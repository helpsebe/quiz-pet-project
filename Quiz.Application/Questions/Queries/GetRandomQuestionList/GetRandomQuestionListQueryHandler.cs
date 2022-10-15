using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Quiz.Application.Interfaces;
using Quiz.Application.Questions.Queries.GetQuestionList;

namespace Quiz.Application.Questions.Queries.GetRandomQuestionList
{
    public class GetRandomQuestionListQueryHandler
        : IRequestHandler<GetRandomQuestionListQuery, QuestionListVm>
    {
        private readonly IQuizDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetRandomQuestionListQueryHandler(IQuizDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<QuestionListVm> Handle(GetRandomQuestionListQuery request, CancellationToken cancellationToken)
        {
            //Take random 10 questions from the list
            var questionsQuery = await _dbContext.Questions
                .ProjectTo<QuestionLookupDto>(_mapper.ConfigurationProvider)
                .OrderBy(arg => Guid.NewGuid())
                .Take(10)
                .ToListAsync();

            return new QuestionListVm { Questions = questionsQuery };
        }
    }
}
