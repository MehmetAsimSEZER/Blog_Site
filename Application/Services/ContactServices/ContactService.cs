using Application.Models.DTOs;
using Application.Models.VMs;
using AutoMapper;
using Domain.Enums;
using Domain.Models.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ContactServices
{
    public class ContactService : IContactService
    {
        private IMapper _mapper;
        private IContactRepository _contactRepository;
        public ContactService(IMapper mapper, IContactRepository contactRepository)
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
        }

        public async Task Create(CreateContactDTO model)
        {
            var contact = _mapper.Map<Contact>(model);
            await _contactRepository.Create(contact);
        }

        public async Task Delete(int id)
        {
            Contact contact = await _contactRepository.GetDefault(x => x.Id == id);
            contact.DeleteDate = DateTime.Now;
            contact.Status = Status.Passive;
            await _contactRepository.Delete(contact);
        }

        public async Task<UpdateContactDTO> GetById(int id)
        {
            var contact = await _contactRepository.GetFilteredFirstOrDefault(
                select: x => new ContactVM
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    Phone = x.Phone,
                    Message = x.Message
                },
                where: x => x.Id == id);
            var model = _mapper.Map<UpdateContactDTO>(contact);
            return model;
        }

        public async Task<List<ContactVM>> GetContacts()
        {
            var contacts = await _contactRepository.GetFilteredList(
                select: x => new ContactVM
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    Phone = x.Phone,
                    Message = x.Message
                },
                where: x => x.Status != Status.Passive,
                orderBy: x => x.OrderBy(x => x.Id));
            return contacts;
        }
    }
}
