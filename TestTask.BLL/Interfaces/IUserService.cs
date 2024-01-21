using TestTask.BLL.DTO;

namespace TestTask.BLL.Interfaces;

public interface IUserService
{
    Task<UserDto> GetUserAsync(int userId);
    Task<UserDto> AddUserAsync(CreateUserDto createUserDto);
    Task RemoveUserAsync(int userId);
    Task<UserDto> UpdateUserAsync(int userId, UpdateUserDto updateUserDto);
}