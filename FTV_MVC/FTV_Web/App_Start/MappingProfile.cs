using AutoMapper;
using FTV.DAL.Models;
using FTV.DAL.ViewModels;
using FTV_Web.Models;

namespace FTV_Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserModel, EditUserViewModel>().ReverseMap();
            
//            CreateMap<EditViewModel, UserModel>().ReverseMap();
//            CreateMap<UserModel, RegisterViewModel>().ReverseMap();
        }
    }
}