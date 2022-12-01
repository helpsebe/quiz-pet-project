using Quiz.Application.Users.Queries.GetUser;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.WebApi.Helpers.Services.Interfaces
{
    public interface IJwtService
    {
        public string Generate(UserVm user);
       // public JwtSecurityToken Verify(string jwt);
    }
}
