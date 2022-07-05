using Application.Models.DTOs;
using Application.Models.VMs;
using AutoMapper;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AppUser, RegisterDTO>().ReverseMap();
            CreateMap<AppUser, LoginDTO>().ReverseMap();
            CreateMap<AppUser, ProfileDTO>().ReverseMap();

            CreateMap<Post, CreatePostDTO>().ReverseMap();
            CreateMap<Post, UpdatePostDTO>().ReverseMap();
            CreateMap<Post, PostVM>().ReverseMap();
            CreateMap<UpdatePostDTO, PostVM>().ReverseMap();

            CreateMap<Author, CreateAuthorDTO>().ReverseMap();
            CreateMap<Author, UpdateAuthorDTO>().ReverseMap();
            CreateMap<Author, AuthorVM>().ReverseMap();
            CreateMap<UpdateAuthorDTO, AuthorVM>().ReverseMap();

            CreateMap<Contact, CreateContactDTO>().ReverseMap();
            CreateMap<Contact, ContactVM>().ReverseMap();
        }
    }
}
