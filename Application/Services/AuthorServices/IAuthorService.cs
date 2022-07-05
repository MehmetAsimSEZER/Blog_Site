using Application.Models.DTOs;
using Application.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AuthorServices
{
    public interface IAuthorService
    {
        Task Create(CreateAuthorDTO model);
        Task Update(UpdateAuthorDTO model);
        Task Delete(int id);

        Task<AuthorVM> GetDetails(int id);

        Task<UpdateAuthorDTO> GetById(int id);

        Task<bool> isAuthorExsist(string firstName, string lastName);
    }
}
