using AutoMapper;
using TestTask.BLL.DTO;
using TestTask.BLL.Exceptions;
using TestTask.BLL.Interfaces;
using TestTask.DAL.Context;
using TestTask.DAL.Entities;

namespace TestTask.BLL.Services;

public class UserService : IUserService
{
    private readonly TestTaskContext _context;
    private readonly IMapper _mapper;
    public UserService(TestTaskContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserDto> GetUserAsync(int userId)
    {
        var user = await _context.Users.FindAsync(userId);
        ValidateUser(user, userId);

        return _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> AddUserAsync(CreateUserDto createUserDto)
    {
        var user = _mapper.Map<User>(createUserDto);

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return _mapper.Map<UserDto>(user);
    }
    
    public async Task RemoveUserAsync(int userId)
    {
        var user = await _context.Users.FindAsync(userId);

        ValidateUser(user, userId);

        _context.Users.Remove(user!);
        await _context.SaveChangesAsync();
    }

    public async Task<UserDto> UpdateUserAsync(int userId, UpdateUserDto updateUserDto)
    {
        var user = await _context.Users.FindAsync(userId);

        ValidateUser(user, userId);

        _mapper.Map(updateUserDto, user);

        await _context.SaveChangesAsync();

        return _mapper.Map<UserDto>(user);
    }
    
    private void ValidateUser(User? user, int userId)
    {
        if (user is null)
        {
            throw new EntityNotFoundException(nameof(user), userId);
        }
    }
}