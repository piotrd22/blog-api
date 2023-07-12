using AutoMapper;
using Blog.DTOs.PostDTO;

namespace Blog.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<CreatePostRequest, Post>()
                .ForMember(
                    dest => dest.Title,
                    opt => opt.MapFrom(src => src.Title))
                 .ForMember(
                    dest => dest.Description,
                    opt => opt.MapFrom(src => src.Description))
                .ForMember(
                    dest => dest.CreatedAt,
                    opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(
                    dest => dest.UpdatedAt,
                    opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<UpdatePostRequest, Post>()
                 .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(
                    dest => dest.Title,
                    opt => opt.MapFrom(src => src.Title))
                 .ForMember(
                    dest => dest.Description,
                    opt => opt.MapFrom(src => src.Description))
                .ForMember(
                    dest => dest.CreatedAt,
                    opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(
                    dest => dest.UpdatedAt,
                    opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<Post, PostDTO>();
        }
    }
}
