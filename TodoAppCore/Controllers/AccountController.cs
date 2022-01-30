using Microsoft.AspNetCore.Mvc;

namespace TodoAppCore.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Register()
        //{
        //    return View();
        //}

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Login()
        //{
        //    return View();
        //}
    }
}
