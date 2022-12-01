using AutoMapper;
using Quiz.Application.Common.Mappings;
using Quiz.Application.Users.Commands.UpdateUserScore;

namespace Quiz.WebApi.Models.Users
{
    public class UpdateUserScoreDto : IMapWith<UpdateUserScoreCommand>
    {
        public Guid Id { get; set; }
        public int Score { get; set; }
        public int TimeTaken { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateUserScoreDto, UpdateUserScoreCommand>();
        }
    }
}
