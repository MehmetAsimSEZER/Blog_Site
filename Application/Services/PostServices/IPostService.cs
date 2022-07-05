using Application.Models.DTOs;
using Application.Models.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.PostServices
{
    public interface IPostService
    {
        Task Create(CreatePostDTO model);
        Task Update(UpdatePostDTO model);
        Task Delete(int id);
        Task<UpdatePostDTO> GetById(int id);
        Task<List<PostVM>> GetPosts();
        Task<PostDetailsVM> GetPostDetails(int id);
    }
}
