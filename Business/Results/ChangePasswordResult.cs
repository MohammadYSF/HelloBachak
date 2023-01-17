namespace Business.Results;
public class ChangePasswordResult
{
    public ChangePasswordResult(ChangePasswordDtoValidationResult validationResult, Language lang)
    {
        this.Success = validationResult.Success;
        if (lang == Language.English)
        {
            
            // ///////////new password
            if (validationResult.NewPasswordErrorMessages.Contains("invalid-newPassword")
            && validationResult.NewPasswordErrorMessages.Contains("duplicate-newPassword"))
            {
                this.NewPasswordErrorMessage = "new password is not valid and also it is duplicate";
            }
            else if (validationResult.NewPasswordErrorMessages.Contains("invalid-newPassword"))
            {
                this.NewPasswordErrorMessage = "new password is not valid";

            }
            else if (validationResult.NewPasswordErrorMessages.Contains("duplicate-newPassword"))
            {
                this.NewPasswordErrorMessage = "new password is duplicate";

            }
            /////// current password
            if (validationResult.CurrentPasswordErrorMessages.Contains("invalid-currentPassword")){
                this.CurrentPasswordErrorMessage = "the entered current password is wrong";
            }
            // user id
            if (validationResult.UserIdErrorMessages.Contains("invalid-userId")){
                this.UserIdErrorMessage = "entered user id is invalid";
            }
         
    

        }
        else if (lang == Language.Persian)
        {
          
            // ///////////رمز عبور جدید
            if (validationResult.NewPasswordErrorMessages.Contains("invalid-newPassword")
            && validationResult.NewPasswordErrorMessages.Contains("duplicate-newPassword"))
            {
                this.NewPasswordErrorMessage = "رمز عبور جدید نامعتبر و تکراری است";
            }
            else if (validationResult.NewPasswordErrorMessages.Contains("invalid-newPassword"))
            {
                this.NewPasswordErrorMessage = "رمز عبور جدید نامعتبر است";

            }
            else if (validationResult.NewPasswordErrorMessages.Contains("duplicate-newPassword"))
            {
                this.NewPasswordErrorMessage = "رمز عبور جدید تکراری است";

            }
            ///// شناسه کاربر
            if (validationResult.UserIdErrorMessages.Contains("invalid-userId")){
                this.UserIdErrorMessage = "شناسه کاربر وارد شده نامعتبر است";
            }
            //رمز عبور فعلی
             if (validationResult.CurrentPasswordErrorMessages.Contains("invalid-currentPassword")){
                this.CurrentPasswordErrorMessage = "رمز عبور فعلی وارد شده نامعتبر است";
             }
            
     
        }
    }
    public bool Success { get; set; }
    public string UserIdErrorMessage { get; set; }
    public string CurrentPasswordErrorMessage { get; set; } = "";
    public string NewPasswordErrorMessage { get; set; } = "";
}

