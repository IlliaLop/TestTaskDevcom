namespace TestTask.BLL.DTO;

public class UserDto
{
    public int UserId { get; set; }
    public string Login { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public char Gender { get; set; }
}