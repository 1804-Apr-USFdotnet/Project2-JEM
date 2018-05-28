using AutoMapper;
using FTV.DAL.Models;
using FTV.DAL.ViewModels;

namespace FTV.SL.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<UserViewModel, User>().ReverseMap();
            CreateMap<UserViewModel, ShowUserViewModel>().ReverseMap();
            CreateMap<UserEditViewModel, User>().ReverseMap();
            CreateMap<UserEditViewModel, UserViewModel>().ReverseMap();
            CreateMap<Comment, CommentViewModel>().ReverseMap();
            CreateMap<Comment, EditCommentViewModel>().ReverseMap();
            CreateMap<FollowedPlayer, FollowedPlayerViewModel>().ReverseMap();
            
        }
    }
}