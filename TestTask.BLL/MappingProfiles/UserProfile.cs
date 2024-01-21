using AutoMapper;
using TestTask.BLL.DTO;
using TestTask.DAL.Entities;

namespace TestTask.BLL.MappingProfiles;

public sealed class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, CreateUserDto>()!.ReverseMap();
        CreateMap<User, UpdateUserDto>()!.ReverseMap();
        CreateMap<User, UserDto>()!.ReverseMap();
    }
}