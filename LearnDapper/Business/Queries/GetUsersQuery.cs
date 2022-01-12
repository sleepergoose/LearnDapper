using LearnDapper.DAL.Repositories;
using LearnDapper.Models;
using MediatR;
using Dapper;
using System.Collections.Generic;
using System.Data;
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
        private readonly IDbConnection _connection;

        public GetUsersQueryHandler(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<ICollection<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return (await _connection.QueryAsync<User>("SELECT * FROM Users")).ToList();
        }
    }
}
