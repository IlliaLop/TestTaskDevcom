using Microsoft.AspNetCore.Mvc;
using TestTask.BLL.DTO;
using TestTask.BLL.Interfaces;

namespace TestTask.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController: ControllerBase
{
    private readonly IUserService _userService;
    
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet("{userId}")]
    public async Task<ActionResult<UserDto>> GetUserAsync(int userId)
    {
        return Ok(await _userService.GetUserAsync(userId));
    }
    
    [HttpPost]
    public async Task<IActionResult> AddUserAsync([FromBody] CreateUserDto createUserDto)
    {
        return Ok(await _userService.AddUserAsync(createUserDto));
    }

    [HttpDelete("{userId}")]
    public async Task<IActionResult> RemoveUserAsync(int userId)
    {
        await _userService.RemoveUserAsync(userId);
        return NoContent();
    }

    [HttpPut("{userId}")]
    public async Task<IActionResult> UpdateUser(int userId, [FromBody] UpdateUserDto updateUserDto)
    {
        return Ok(await _userService.UpdateUserAsync(userId, updateUserDto));
    }
}