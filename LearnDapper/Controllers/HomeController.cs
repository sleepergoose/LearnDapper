using LearnDapper.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnDapper.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository _repo;

        public HomeController(IUserRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View("Index", _repo.GetUsers());
        }

        public IActionResult GetUser(int id)
        {
            return View("UserView", _repo.Get(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("CreateUser");
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            _repo.Create(user);
            return View("Index", _repo.GetUsers());
        }
    }
}
