using FluentValidation;

namespace Quiz.Application.Questions.Queries.GetQuestion
{
    public class GetQuestionQueryValidator : AbstractValidator<GetQuestionQuery>
    {
        public GetQuestionQueryValidator()
        {
            RuleFor(qstn => qstn.Id).NotEmpty();
        }
    }
}
