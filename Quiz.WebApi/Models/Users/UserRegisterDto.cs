using AutoMapper;
using Quiz.Application.Common.Mappings;
using Quiz.Application.Users.Commands.CreateRegisteredUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.WebApi.Models.Users
{
    public class UserRegisterDto:IMapWith<CreateUserCommand>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserRegisterDto, CreateUserCommand>();
        }
    }
}
