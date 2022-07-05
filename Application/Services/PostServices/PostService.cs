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

namespace Application.Services.PostServices
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task Create(CreatePostDTO model)
        {
            var post = _mapper.Map<Post>(model);
            await _postRepository.Create(post);
        }

        public async Task Delete(int id)
        {
            Post post = await _postRepository.GetDefault(x => x.Id == id);
            post.DeleteDate = DateTime.Now;
            post.Status = Status.Passive;
            await _postRepository.Delete(post);
        }

        public async Task<UpdatePostDTO> GetById(int id)
        {
            var post = await _postRepository.GetFilteredFirstOrDefault(
                select: x => new PostVM
                {
                    Title = x.Title,
                    Content = x.Content,
                },
                where: x => x.Id == id);

            var model = _mapper.Map<UpdatePostDTO>(post);

            return model;
        }

        public async Task<PostDetailsVM> GetPostDetails(int id)
        {
            var post = await _postRepository.GetFilteredFirstOrDefault(
                select: x => new PostDetailsVM
                {
                    Title = x.Title,
                    Content = x.Content,
                },
                where: x => x.Id == id,
                orderBy: x => x.OrderBy(x => x.Title));

            return post;
        }

        public async Task<List<PostVM>> GetPosts()
        {
            var posts = await _postRepository.GetFilteredList(
                select: x => new PostVM
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content
                },
                where: x => x.Status != Status.Passive,
                orderBy: x => x.OrderBy(x => x.Id));
            return posts;
        }

        public async Task Update(UpdatePostDTO model)
        {
            var post = _mapper.Map<Post>(model);
            await _postRepository.Update(post);
        }
    }
}
