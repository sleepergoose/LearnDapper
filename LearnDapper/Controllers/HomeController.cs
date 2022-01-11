using LearnDapper.Business.Commands;
using LearnDapper.Business.Queries;
using LearnDapper.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LearnDapper.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _mediator.Send(new GetUsersQuery());

            return View("Index", users);
        }

        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery() { UserId = id });

            return View("UserView", user);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("CreateUser");
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            var command = new AddUserCommand
            {
                Name = user.Name,
                Age = user.Age
            };

            User createdUser = await _mediator.Send(command);
            return View("UserView", createdUser);
        }
    }
}
