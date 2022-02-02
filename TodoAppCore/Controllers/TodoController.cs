using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoAppCore.Core.IConfiguration;
using TodoAppCore.Entities;
using TodoAppCore.Models;

namespace TodoAppCore.Controllers
{
    [Authorize]
    public class TodoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TodoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> AddTodo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTodo(AddTodoModel model)
        {
            AppUser user = await _unitOfWork.Users.GetUser(User);
            if (ModelState.IsValid)
            {
                Todo todo = new Todo()
                {
                    AppUserId = user.Id,
                    Title = model.Title,
                    Content = model.Content,
                    CreatedDate = DateTime.Now,
                    IsCompleted = false,
                    IsDeleted = false,
                };
                var result = await _unitOfWork.Todos.Add(todo);
                if (result)
                {
                    await _unitOfWork.CompleteAsync();
                    return RedirectToAction("Index", "Home");
                }
                ViewData["HasError"] = true;
                ModelState.AddModelError("", "Something went wrong.");
            }
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return RedirectToAction("Index", "Home");

            AppUser user = await _unitOfWork.Users.GetUser(User);
            var todo = await _unitOfWork.Todos.GetById((int)id, user);
            if (todo == null)
                return RedirectToAction("Index", "Home");
            DetailsModel model = new DetailsModel()
            {
                Content = todo.Content,
                CreatedDate = todo.CreatedDate,
                IsCompleted = todo.IsCompleted,
                Id = todo.Id,
                IsDeleted = todo.IsDeleted,
                Title = todo.Title,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            AppUser user = await _unitOfWork.Users.GetUser(User);
            var result = await _unitOfWork.Todos.DeleteByIdSoft(id, user);

            if (result)
            {
                await _unitOfWork.CompleteAsync();
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Details");
        }

        [HttpPost]
        public async Task<IActionResult> Done(int id)
        {
            var result = await _unitOfWork.Todos.CompleteTodo(id);

            if (result)
            {
                await _unitOfWork.CompleteAsync();
            }
            return RedirectToAction("Details", new { id = id });
        }

    }
}
