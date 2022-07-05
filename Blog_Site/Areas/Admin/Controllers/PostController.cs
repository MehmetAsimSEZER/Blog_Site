using Application.Models.DTOs;
using Application.Services.PostServices;
using Microsoft.AspNetCore.Mvc;

namespace Presantation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService) => _postService = postService;

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePostDTO model)
        {
            if (ModelState.IsValid)
            {
                await _postService.Create(model);
                TempData["Success"] = "Post has been added";
                return RedirectToAction("List");
            }
            else
            {
                TempData["Error"] = "Post hasn't been added";
                return View(model);
            }
        }

        public async Task<IActionResult> List() => View(await _postService.GetPosts());

        public async Task<IActionResult> Update(int id) => View(await _postService.GetById(id));

        public async Task<IActionResult> Details(int id) => View(await _postService.GetPostDetails(id));

        [HttpPost]
        public async Task<IActionResult> Update(UpdatePostDTO model)
        {
            if (ModelState.IsValid)
            {
                await _postService.Update(model);
                TempData["Success"] = "Post has been added";
                return RedirectToAction("List");
            }
            else
            {
                TempData["Error"] = "Post hasn't been added";
                return View(model);
            }
        }
    }
}
