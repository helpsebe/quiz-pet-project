using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Questions.Queries.GetRandomQuestionList
{
    public class GetRandomQuestionListQueryValidator:AbstractValidator<GetRandomQuestionListQuery>
    {
        public GetRandomQuestionListQueryValidator()
        {
            //empty
        }
    }
}
