using FluentValidation;

namespace Quiz.Application.Questions.Commands.DeleteQuestion
{
    public class DeleteQuestionCommandValidator : AbstractValidator<DeleteQuestionCommand>
    {
        public DeleteQuestionCommandValidator()
        {
            RuleFor(deleteQuestionCommand =>
                deleteQuestionCommand.Id).NotEmpty();
        }
    }
}
