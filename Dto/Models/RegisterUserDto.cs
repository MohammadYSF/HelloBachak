namespace Dto.Models;

public class RegisterUserDto
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int SexId { get; set; }
    public Int16 Age { get; set; }
    public int GradeId { get; set; }
    public string PhoneNumber { get; set; }
    
}
