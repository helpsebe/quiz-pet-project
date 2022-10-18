using AutoMapper;
using Quiz.Application.Common.Mappings;
using Quiz.Application.Questions.Commands.UpdateQuestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.WebApi.Models
{
    public class UpdateQuestionDto:IMapWith<UpdateQuestionCommand>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string? Option4 { get; set; }
        public int Answer { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateQuestionDto, UpdateQuestionCommand>();
        }
    }
}
