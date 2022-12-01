using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Quiz.Application.Common.Exceptions;
using Quiz.Application.Interfaces;
using Quiz.Application.Users.Queries.GetUser;
using Quiz.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler
        :IRequestHandler<GetUserByIdQuery, UserVm>
    {
        private readonly IQuizDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetUserByIdQueryHandler(IQuizDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<UserVm> Handle(GetUserByIdQuery request,
            CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(u =>
                u.Id == request.Id, cancellationToken);

            if (user == null || user.Id != request.Id)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            return _mapper.Map<UserVm>(user);
        }
    }
}
