using MediatR;

namespace Quiz.Application.Questions.Commands.DeleteQuestion
{
    public class DeleteQuestionCommand : IRequest
    {
        public int Id { get; set; }
    }
}
