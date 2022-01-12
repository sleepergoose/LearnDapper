using LearnDapper.Business.Commands;
using LearnDapper.Business.Queries;
using LearnDapper.Business.Services;
using LearnDapper.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LearnDapper.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserService _userService;

        public HomeController(UserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetUsersAsync();

            return View("Index", users);
        }

        public IActionResult GetUser()
        {
            return View("UserView");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("CreateUser");
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            User createdUser = await _userService.CreateUserAsync(user);
            return View("UserView", createdUser);
        }
    }
}
