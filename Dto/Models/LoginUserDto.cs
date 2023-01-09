namespace Dto.Models;

public class LoginUserDto
{
    public int Email { get; set; }
    public string Password { get; set; }
    public bool RememberMe { get; set; }
}
