using AutoMapper;
using Quiz.Application.Common.Mappings;
using Quiz.Application.Users.Commands.UpdateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Quiz.WebApi.Models.Users
{
    public class UpdateUserInfoDto:IMapWith<UpdateUserInformationCommand>
    {
        //[JsonIgnore]
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateUserInfoDto, UpdateUserInformationCommand>();
        }
    }
}
