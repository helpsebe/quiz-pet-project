using AutoMapper;
using Quiz.Application.Common.Mappings;
using Quiz.Domain;

namespace Quiz.Application.Questions.Queries.GetQuestion
{
    public class QuestionVm : IMapWith<Question>
    {
        public string Title { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public int Answer { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Question, QuestionVm>();
        }
    }
}
