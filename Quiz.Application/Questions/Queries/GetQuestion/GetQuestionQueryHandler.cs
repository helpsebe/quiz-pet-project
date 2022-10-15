using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Quiz.Application.Common.Exceptions;
using Quiz.Application.Interfaces;
using Quiz.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Questions.Queries.GetQuestion
{
    public class GetQuestionQueryHandler
        : IRequestHandler<GetQuestionQuery, QuestionVm>
    {
        private readonly IQuizDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetQuestionQueryHandler(IQuizDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<QuestionVm> Handle(GetQuestionQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Questions
                .FirstOrDefaultAsync(qstn =>
                qstn.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Question), request.Id);
            }

            return _mapper.Map<QuestionVm>(entity);
        }
    }
}
