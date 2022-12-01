using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Users.Commands.DeteleUser
{
    public class DeleteUserCommand:IRequest
    {
        public Guid Id { get; set; }
    }
}
