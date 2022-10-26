using FluentValidation;

namespace Quiz.Application.Questions.Commands.UpdateQuestion
{
    public class UpdateQuestionCommandValidator : AbstractValidator<UpdateQuestionCommand>
    {
        public UpdateQuestionCommandValidator()
        {
            RuleFor(updateQuestionCommand =>
            updateQuestionCommand.Id).NotEmpty();
            RuleFor(updateQuestionCommand =>
            updateQuestionCommand.Title).NotEmpty().MaximumLength(40);

            RuleFor(updateQuestionCommand =>
            updateQuestionCommand.Option1).NotEmpty().MaximumLength(60);
            RuleFor(updateQuestionCommand =>
            updateQuestionCommand.Option2).NotEmpty().MaximumLength(60);
            RuleFor(updateQuestionCommand =>
            updateQuestionCommand.Option3).NotEmpty().MaximumLength(60);
            RuleFor(updateQuestionCommand =>
            updateQuestionCommand.Option4).NotEmpty().MaximumLength(60);

            RuleFor(updateQuestionCommand =>
            updateQuestionCommand.Answer).NotEmpty();
        }
    }
}
