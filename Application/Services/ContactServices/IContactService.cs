using Application.Models.DTOs;
using Application.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ContactServices
{
    public interface IContactService
    {
        Task Create(CreateContactDTO model);
        Task Delete(int id);
        Task<UpdateContactDTO> GetById(int id);
        Task<List<ContactVM>> GetContacts();
    }
}
