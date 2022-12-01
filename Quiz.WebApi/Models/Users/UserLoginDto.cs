using AutoMapper;
using Quiz.Application.Common.Mappings;
using Quiz.Application.Users.Queries.GetUser;
using Quiz.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.WebApi.Models.Users
{
    public class UserLoginDto:IMapWith<UserVm>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserLoginDto, UserVm >();
        }
    }
}
