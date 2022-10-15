using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Questions.Queries.GetQuestionList
{
    public class GetQuestionListQuery
        : IRequest<QuestionListVm>
    {
        //
    }
}
