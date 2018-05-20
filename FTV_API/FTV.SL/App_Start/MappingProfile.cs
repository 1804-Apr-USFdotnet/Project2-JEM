using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using FTV.DAL.Dtos;
using FTV.DAL.Models;

namespace FTV.SL.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<UserViewModel, User>().ReverseMap();
        }
    }
}