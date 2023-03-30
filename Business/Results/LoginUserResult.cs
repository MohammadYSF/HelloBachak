namespace Business.Results;

public class LoginUserResult
{
    public LoginUserResult(LoginUserDtoValidationResult validationResult, Language lang , string token , string refreshToken)
    {
        this.Success = validationResult.Success;
        this.Token = token;
        this.RefreshToken = refreshToken;
        if (lang == Language.English)
        {            
            // ///////////password
            if (validationResult.PasswordErrorMessages.Contains("invalid-password")
            && validationResult.PasswordErrorMessages.Contains("duplicate-password"))
            {
                this.PasswordErrorMessage = "password is not valid and also it is duplicate";
            }
            else if (validationResult.PasswordErrorMessages.Contains("invalid-password"))
            {
                this.PasswordErrorMessage = "password is not valid";

            }
            else if (validationResult.PasswordErrorMessages.Contains("duplicate-password"))
            {
                this.PasswordErrorMessage = "password is duplicate";

            }
            // ///////// email
            if (validationResult.EmailErrorMessages.Contains("invalid-email")
            && validationResult.EmailErrorMessages.Contains("duplicate-email"))
            {
                this.EmailErrorMessage = "email is not valid and also it is duplicate";
            }
            else if (validationResult.EmailErrorMessages.Contains("invalid-email"))
            {
                this.EmailErrorMessage = "email is not valid";

            }
            else if (validationResult.EmailErrorMessages.Contains("duplicate-email"))
            {
                this.EmailErrorMessage = "you already have an acount with this email . please go to the login page";

            }
          

        }
        else if (lang == Language.Persian)
        {
            
            // ///////////رمز عبور
            if (validationResult.PasswordErrorMessages.Contains("invalid-password")
            && validationResult.PasswordErrorMessages.Contains("duplicate-password"))
            {
                this.PasswordErrorMessage = "رمز عبور نامعتبر و تکراری است";
            }
            else if (validationResult.PasswordErrorMessages.Contains("invalid-password"))
            {
                this.PasswordErrorMessage = "رمز عبور نامعتبر است";

            }
            else if (validationResult.PasswordErrorMessages.Contains("duplicate-password"))
            {
                this.PasswordErrorMessage = "رمز عبور تکراری است";

            }
            // ///////// آدرس ایمیل
            if (validationResult.EmailErrorMessages.Contains("invalid-email")
            && validationResult.EmailErrorMessages.Contains("duplicate-email"))
            {
                this.EmailErrorMessage = "آدرس ایمیل وارد شده نامعتبر و تکراری است";
            }
            else if (validationResult.EmailErrorMessages.Contains("invalid-email"))
            {
                this.EmailErrorMessage = "آدرس ایمیل وارد شده نامعتبر است";

            }
            else if (validationResult.EmailErrorMessages.Contains("duplicate-email"))
            {
                this.EmailErrorMessage = "حسابی با این آدرس ایمیل موجود است . لطفا به صفحه ورود مراجعه کنید";

            }
            
        }
    }
    public bool Success { get; set; }
    public string PasswordErrorMessage { get; set; } = "";
    public string EmailErrorMessage { get; set; } = "";
    public string Token { get; set; }
    public string RefreshToken { get; set; }
}

