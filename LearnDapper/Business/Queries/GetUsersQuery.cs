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
    public class GetUsersQuery : IRequest<ICollection<User>>
    {

    }

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, ICollection<User>>
    {
        private readonly IUserRepository _repo;

        public GetUsersQueryHandler(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<ICollection<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetUsersAsync();
        }
    }
}
