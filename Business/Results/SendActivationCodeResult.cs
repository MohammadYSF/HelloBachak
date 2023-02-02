namespace Business.Results;
public class SendActivationCodeResult
{
    public SendActivationCodeResult(SendActivationCodeDtoValidationResult validationResult, Language lang)
    {
        this.Success = validationResult.Success;
        if (lang == Language.English)
        {

            // ///////// email
            
             if (validationResult.EmailErrorMessages.Contains("invalid-email"))
            {
                this.EmailErrorMessage = "email is not valid";

            }
            else if (validationResult.EmailErrorMessages.Contains("not-found-email"))
            {
                this.EmailErrorMessage = "email not found";

            }
            

        }
        else if (lang == Language.Persian)
        {
            // ///////// آدرس ایمیل
            
            if (validationResult.EmailErrorMessages.Contains("invalid-email"))
            {
                this.EmailErrorMessage = "آدرس ایمیل وارد شده نامعتبر است";

            }
            else if (validationResult.EmailErrorMessages.Contains("not-found-email"))
            {
                this.EmailErrorMessage = "حسابی با این آدرس ایمیل یافت نشد";
            }
            
        }
    }
    public bool Success { get; set; }
    public string EmailErrorMessage { get; set; } = "";
}

