using AutoMapper;
using Quiz.Application.Common.Mappings;
using Quiz.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Quiz.Application.Users.Queries.GetUser
{
    public class UserVm:IMapWith<User>
    {
        //[JsonIgnore]
        //public Guid Id { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        [JsonIgnore]
        //public string Role { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public int TimeTaken { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserVm>();
        }
    }
}
