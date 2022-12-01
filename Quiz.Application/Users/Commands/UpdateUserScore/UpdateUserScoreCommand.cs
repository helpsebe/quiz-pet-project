using MediatR;
using Quiz.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Users.Commands.UpdateUserScore
{
    public class UpdateUserScoreCommand:IRequest
    {
        public Guid Id { get; set; }
        public int Score { get; set; }
        public int TimeTaken { get; set; }
    }
}
