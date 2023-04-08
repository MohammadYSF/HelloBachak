namespace Business.Results;

public class LoginUserResult
{
    public LoginUserResult(LoginUserDtoValidationResult validationResult, Language lang , string token , string refreshToken , string username , string roleTitle)
    {
        this.RoleTitle = roleTitle;
        this.Username = username;
        this.Success = validationResult.Success;
        this.Token = token;
        this.RefreshToken = refreshToken;
        if (lang == Language.English)
        {            
            // ///////////password
          
            if (validationResult.PasswordErrorMessages.Contains("wrong-password"))
            {
                this.PasswordErrorMessage = "password is wrong";

            }
    
            // ///////// email
          
             if (validationResult.EmailErrorMessages.Contains("notexist-email"))
            {
                this.EmailErrorMessage = "email does not exist";

            }
          
          

        }
        else if (lang == Language.Persian)
        {
            
            // ///////////رمز عبور
            
            if (validationResult.PasswordErrorMessages.Contains("wrong-password"))
            {
                this.PasswordErrorMessage = "رمز عبور وارد شده اشتباه است";

            }
            
            // ///////// آدرس ایمیل
          
            if (validationResult.EmailErrorMessages.Contains("notexist-email"))
            {
                this.EmailErrorMessage = "چنین ایمیلی وجود ندارد";

            }
          
            
        }
    }
    public bool Success { get; set; }
    public string PasswordErrorMessage { get; set; } = "";
    public string EmailErrorMessage { get; set; } = "";
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public string Username { get; set; }
    public string RoleTitle { get; set; }
}

