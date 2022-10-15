using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Questions.Queries.GetQuestion
{
    public class GetQuestionQuery : IRequest<QuestionVm>
    {
        public int Id { get; set; }
    }
}
