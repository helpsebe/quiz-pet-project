using FluentValidation;

namespace Quiz.Application.Questions.Commands.CreateQuestion
{
    public class CreateQuestionCommandValidator : AbstractValidator<CreateQuestionCommand>
    {
        public CreateQuestionCommandValidator()
        {
            RuleFor(createQuestionCommand =>
            createQuestionCommand.Title).NotEmpty().MaximumLength(40);

            RuleFor(createQuestionCommand =>
            createQuestionCommand.Option1).NotEmpty().MaximumLength(60);
            RuleFor(createQuestionCommand =>
            createQuestionCommand.Option2).NotEmpty().MaximumLength(60);
            RuleFor(createQuestionCommand =>
            createQuestionCommand.Option3).NotEmpty().MaximumLength(60);
            RuleFor(createQuestionCommand =>
            createQuestionCommand.Option4).MaximumLength(60);

            RuleFor(createQuestionCommand =>
            createQuestionCommand.Answer).NotEmpty();
        }
    }
}
