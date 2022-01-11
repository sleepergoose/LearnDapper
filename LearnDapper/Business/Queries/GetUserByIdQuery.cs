using LearnDapper.DAL.Repositories;
using LearnDapper.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LearnDapper.Business.Queries
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public int UserId { get; set; }
    }

    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IUserRepository _repo;

        public GetUserByIdQueryHandler(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetAsync(request.UserId);
        }
    }
}
