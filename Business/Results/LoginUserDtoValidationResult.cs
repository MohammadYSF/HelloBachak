using FluentValidation.Results;
namespace Business.Results;

public class LoginUserDtoValidationResult
{

    public LoginUserDtoValidationResult(ValidationResult validationResult)
    {
        var validationFailures = validationResult.Errors;
        this.Success = validationResult.IsValid;
        if (!validationResult.IsValid)
        {

            this.Success = false;
            if (validationFailures.Any(a => a.PropertyName == "Email"))
            {
                this.EmailErrorMessages.Add(validationFailures.Find(a => a.PropertyName == "Email").ErrorMessage);
            }
            if (validationFailures.Any(a => a.PropertyName == "Password"))
            {
                this.PasswordErrorMessages.Add(validationFailures.Find(a => a.PropertyName == "Password").ErrorMessage);
            }
           
        }
    }
    public bool Success { get; set; }
    public List<string> EmailErrorMessages { get; set; } = new List<string>();
    public List<string> PasswordErrorMessages { get; set; } = new List<string>();
}