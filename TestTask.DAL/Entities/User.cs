namespace TestTask.DAL.Entities;

public class User
{
    public int UserId { get; set; }
        
    public string Login { get; set; } = string.Empty;
        
    public string Password { get; set; } = string.Empty;  //there should be a PasswordHash field and authorization by JWT, but not today xD
        
    public string FirstName { get; set; } = string.Empty;
        
    public string LastName { get; set; } = string.Empty;
        
    public DateTime DateOfBirth { get; set; }
        
    public char Gender { get; set; }

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}