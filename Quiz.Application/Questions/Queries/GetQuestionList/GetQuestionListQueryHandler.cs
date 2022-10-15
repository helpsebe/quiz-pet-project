using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Quiz.Application.Interfaces;

namespace Quiz.Application.Questions.Queries.GetQuestionList
{
    public class GetQuestionListQueryHandler
        : IRequestHandler<GetQuestionListQuery, QuestionListVm>
    {
        private readonly IQuizDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetQuestionListQueryHandler(IQuizDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<QuestionListVm> Handle(GetQuestionListQuery request, CancellationToken cancellationToken)
        {
            var questionsQuery = await _dbContext.Questions
                .ProjectTo<QuestionLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new QuestionListVm { Questions = questionsQuery };
        }
    }
}
