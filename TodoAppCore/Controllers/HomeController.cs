using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using TodoAppCore.Core.IConfiguration;
using TodoAppCore.Entities;
using TodoAppCore.Models;

namespace TodoAppCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unit;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unit)
        {
            _logger = logger;
            _unit = unit;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _unit.Users.GetUser(User);
            if (user != null)
            {
                ViewData["User"] = user.Email;
                var todos = await _unit.Users.GetUserTasks(user);
                var model = new HomeModel()
                {
                    Todos = todos
                };
                return View(model);
            }

            return View();
        }
        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}