using Dapper;
using LearnDapper.DAL.Repositories;
using LearnDapper.Models;
using MediatR;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace LearnDapper.Business.Commands
{
    public class AddUserCommand : IRequest<User>
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, User>
    {
        private readonly IDbConnection _connection;

        public AddUserCommandHandler(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<User> Handle(AddUserCommand command, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Id = 0,
                Name = command.Name,
                Age = command.Age
            };

            const string sql =
                    @"INSERT INTO Users (
                        Name, 
                        Age) 
                    VALUES (
                        @Name, 
                        @Age)
                    SELECT CAST(SCOPE_IDENTITY() as int)";

            var id = await _connection.QueryFirstAsync<int>(sql, user);
            user.Id = id;

            return user;
        }
    }
}
