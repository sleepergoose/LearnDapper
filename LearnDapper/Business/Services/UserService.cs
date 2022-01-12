using LearnDapper.Business.Commands;
using LearnDapper.Business.Queries;
using LearnDapper.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearnDapper.Business.Services
{
    public sealed class UserService
    {
        private readonly IMediator _mediator;

        public UserService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            return await _mediator.Send(new AddUserCommand() { Name = user.Name, Age = user.Age });
        }

        public async Task<ICollection<User>>GetUsersAsync()
        {
            return await _mediator.Send(new GetUsersQuery());
        }
    }
}
