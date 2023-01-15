namespace Business.Results;
public enum Language
{
    Persian,
    English
}
public class RegisterUserResult
{
    public RegisterUserResult(RegisterUserDtoValidationResult validationResult, Language lang)
    {
        this.Success = validationResult.Success;
        if (lang == Language.English)
        {
            //username
            if (validationResult.UsernameErrorMessages.Contains("invalid-username")
            && validationResult.UsernameErrorMessages.Contains("duplicate-username"))
            {
                this.UsernameErrorMessage = "username is not valid and also it is duplicate";
            }
            else if (validationResult.UsernameErrorMessages.Contains("invalid-username"))
            {
                this.UsernameErrorMessage = "username is not valid";

            }
            else if (validationResult.UsernameErrorMessages.Contains("duplicate-username"))
            {
                this.UsernameErrorMessage = "you already have an acount with this user.please go to the login page";

            }
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
            // ///////// phone number
            if (validationResult.PhoneNumberErrorMessages.Contains("invalid-phoneNumber")
            && validationResult.PhoneNumberErrorMessages.Contains("duplicate-phoneNumber"))
            {
                this.PhoneNumberErrorMessage = "phone number is not valid and also it is duplicate";
            }
            else if (validationResult.PhoneNumberErrorMessages.Contains("invalid-phoneNumber"))
            {
                this.PhoneNumberErrorMessage = "phone number is not valid";

            }
            else if (validationResult.PhoneNumberErrorMessages.Contains("duplicate-phoneNumber"))
            {
                this.PhoneNumberErrorMessage = "you already have an acount with this phoneNumber . please go to the phone number";

            }
            // ///////// sex id
            if (validationResult.SexIdErrorMessages.Contains("invalid-sexId"))
            {
                this.SexIdErrorMessage = "sexId is not valid";
            }
            // grade id
            if (validationResult.GradeIdErrorMessages.Contains("invalid-gradeId"))
            {
                this.GradeIdErrorMessage = "gradeId is not valid";
            }

        }
        else if (lang == Language.Persian)
        {
            //نام کاربری
            if (validationResult.UsernameErrorMessages.Contains("invalid-username")
            && validationResult.UsernameErrorMessages.Contains("duplicate-username"))
            {
                this.UsernameErrorMessage = "نام کاربری نامعتبر و تکراری است";
            }
            else if (validationResult.UsernameErrorMessages.Contains("invalid-username"))
            {
                this.UsernameErrorMessage = "نام کاربری نامعتبر است";

            }
            else if (validationResult.UsernameErrorMessages.Contains("duplicate-username"))
            {
                this.UsernameErrorMessage = "حسابی با این نام کاربری موجود است . لطفا به صفحه ورود مراجعه کنید";

            }
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
            // ///////// گوشی همراه
            if (validationResult.PhoneNumberErrorMessages.Contains("invalid-phoneNumber")
            && validationResult.PhoneNumberErrorMessages.Contains("duplicate-phoneNumber"))
            {
                this.PhoneNumberErrorMessage = "شماره تلفن همراه وارد شده تکراری و نامعتبر است";
            }
            else if (validationResult.PhoneNumberErrorMessages.Contains("invalid-phoneNumber"))
            {
                this.PhoneNumberErrorMessage = "شماره تلفن واردشده نامعتبر است";

            }
            else if (validationResult.PhoneNumberErrorMessages.Contains("duplicate-phoneNumber"))
            {
                this.PhoneNumberErrorMessage = "حسابی با این شماره تلفن موجود است . لطفا به صفحه ورود مراجعه کنید";

            }
            // ///////// جنسیت
            if (validationResult.SexIdErrorMessages.Contains("invalid-sexId"))
            {
                this.SexIdErrorMessage = "جنیست وارد شده نامعتبر است";
            }
            // مقطع تحصیلی
            if (validationResult.GradeIdErrorMessages.Contains("invalid-gradeId"))
            {
                this.GradeIdErrorMessage = "مقطع تحصیلی وارد شده نامعتبر است";
            }
        }
    }
    public bool Success { get; set; }
    public string UsernameErrorMessage { get; set; } = "";
    public string PasswordErrorMessage { get; set; } = "";
    public string PhoneNumberErrorMessage { get; set; } = "";
    public string SexIdErrorMessage { get; set; } = "";
    public string GradeIdErrorMessage { get; set; } = "";
    public string EmailErrorMessage { get; set; } = "";
}

