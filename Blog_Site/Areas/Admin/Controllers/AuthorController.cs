using Application.Models.DTOs;
using Application.Services.AuthorServices;
using Microsoft.AspNetCore.Mvc;

namespace Presantation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAuthorDTO model)
        {
            if (ModelState.IsValid)
            {
                await _authorService.Create(model);
                TempData["Success"] = $"{model.FirstName} {model.LastName} has been added..";
                return RedirectToAction("List");
            }
            else
            {
                TempData["warning"] = $"Author already exist..";
                return View(model);
            }

        }


        public async Task<IActionResult> Details(int id)
        {
            var author = await _authorService.GetDetails(id);

            return View(author);
        }

        public async Task<IActionResult> Update(int id)
        {
            var model = await _authorService.GetById(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateAuthorDTO model)
        {
            if (ModelState.IsValid)
            {
                await _authorService.Update(model);
                TempData["Success"] = "Author has been updated..";
                return RedirectToAction("List");
            }
            else
            {
                TempData["Error"] = "Author couldn't updated..";
                return View(model);
            }
        }
    }
}
