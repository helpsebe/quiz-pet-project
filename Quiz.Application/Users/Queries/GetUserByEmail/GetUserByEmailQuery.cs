using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Users.Queries.GetUser
{
    public class GetUserByEmailQuery:IRequest<UserVm>
    {
        public string Email { get; set; }
    }
}
