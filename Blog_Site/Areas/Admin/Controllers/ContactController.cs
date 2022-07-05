using Application.Models.DTOs;
using Application.Services.ContactServices;
using Microsoft.AspNetCore.Mvc;

namespace Presantation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }



        public async Task<IActionResult> List() => View(await _contactService.GetContacts());

        public async Task<IActionResult> Update(int id) => View(await _contactService.GetById(id));


        public async Task<IActionResult> Delete(int id)
        {
            await _contactService.Delete(id);
            return RedirectToAction("List");
        }
    }
}
