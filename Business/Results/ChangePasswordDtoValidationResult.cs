using Entity.Models;
using DataAccess;
using DataAccess.Repositories;
using Dto.Models;
using FluentValidation;
using FluentValidation.Results;
using Business.Validation;
using AutoMapper;
using Business.Helpers;
namespace Business.Results;
public class ChangePasswordDtoValidationResult
{
    
    public ChangePasswordDtoValidationResult(ValidationResult validationResult)
    {
        var validationFailures = validationResult.Errors;
        this.Success = validationResult.IsValid;
        if (!validationResult.IsValid)
        {

            this.Success = false;
            
            if (validationFailures.Any(a => a.PropertyName == "NewPassword"))
            {
                this.CurrentPasswordErrorMessages.Add(validationFailures.Find(a => a.PropertyName == "NewPassword").ErrorMessage);
            }
             if (validationFailures.Any(a => a.PropertyName == "CurrentPasswrod"))
            {
                this.NewPasswordErrorMessages.Add(validationFailures.Find(a => a.PropertyName == "CurrentPasswrod").ErrorMessage);
            }
        }
    }
    public bool Success { get; set; }
    public List<string> CurrentPasswordErrorMessages { get; set; } = new List<string>();
    public List<string> NewPasswordErrorMessages { get; set; } = new List<string>();
}