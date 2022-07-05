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

namespace Application.Services.AuthorServices
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }


        public async Task Create(CreateAuthorDTO model)
        {
            var author = _mapper.Map<Author>(model);

            await _authorRepository.Create(author);
        }

        public async Task Delete(int id)
        {
            var author = await _authorRepository.GetDefault(x => x.Id == id);
            author.DeleteDate = DateTime.Now;
            author.Status = Status.Passive;
            await _authorRepository.Delete(author);
        }

        public async Task<UpdateAuthorDTO> GetById(int id)
        {
            var author = await _authorRepository.GetFilteredFirstOrDefault(
                select: x => new AuthorVM
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Resume = x.Resume,
                    Phone = x.Phone
                },
                where: x => x.Id == id);
            var model = _mapper.Map<UpdateAuthorDTO>(author);
            return model;
        }

        public async Task<AuthorVM> GetDetails(int id)
        {
            var author = await _authorRepository.GetFilteredFirstOrDefault(
                select: x => new AuthorVM
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Resume = x.Resume,
                    Phone = x.Phone
                },
                where: x => x.Id == id);
            return author;
        }

        public async Task<bool> isAuthorExsist(string firstName, string lastName)
        {
            var result = await _authorRepository.Any(x => x.FirstName == firstName && x.LastName == lastName);
            return result;
        }

        public async Task Update(UpdateAuthorDTO model)
        {
            var author = _mapper.Map<Author>(model);

            await _authorRepository.Update(author);
        }
    }
}
