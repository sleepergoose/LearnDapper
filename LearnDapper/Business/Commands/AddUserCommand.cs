using LearnDapper.DAL.Repositories;
using LearnDapper.Models;
using MediatR;
using System;
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
        private readonly IUserRepository _repo;

        public AddUserCommandHandler(IUserRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(_repo));
        }

        public async Task<User> Handle(AddUserCommand command, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Id = 0,
                Name = command.Name,
                Age = command.Age
            };

            return await _repo.CreateAsync(user);
        }
    }
}
