using MediatR;
using Quiz.Application.Users.Queries.GetUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQuery:IRequest<UserVm>
    {
        public Guid Id { get; set; }
    }
}
