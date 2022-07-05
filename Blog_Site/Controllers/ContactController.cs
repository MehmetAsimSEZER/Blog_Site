using Application.Models.DTOs;
using Application.Services.ContactServices;
using Microsoft.AspNetCore.Mvc;

namespace Presantation.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContactDTO model)
        {
            if (ModelState.IsValid)
            {
                await _contactService.Create(model);
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
