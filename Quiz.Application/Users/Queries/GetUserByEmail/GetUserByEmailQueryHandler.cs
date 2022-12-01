using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Quiz.Application.Common.Exceptions;
using Quiz.Application.Interfaces;
using Quiz.Domain;
using System.Net.Http;

namespace Quiz.Application.Users.Queries.GetUser
{
    public class GetUserByEmailQueryHandler
        : IRequestHandler<GetUserByEmailQuery, UserVm>
    {
        private readonly IQuizDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetUserByEmailQueryHandler(IQuizDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<UserVm> Handle(GetUserByEmailQuery request,
            CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(u =>
                u.Email.ToLower() == request.Email.ToLower(), cancellationToken);

            if (user == null || user.Email != request.Email)
            {
                throw new NotFoundException(nameof(User), request.Email);
            }

            return _mapper.Map<UserVm>(user);
        }
    }
}
