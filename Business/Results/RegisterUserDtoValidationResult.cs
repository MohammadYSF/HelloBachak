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
public class RegisterUserDtoValidationResult
{
    
    public RegisterUserDtoValidationResult(ValidationResult validationResult)
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
            if (validationFailures.Any(a => a.PropertyName == "Username"))
            {
                this.UsernameErrorMessages.Add(validationFailures.Find(a => a.PropertyName == "Username").ErrorMessage);
            }
            if (validationFailures.Any(a => a.PropertyName == "SexId"))
            {
                this.SexIdErrorMessages.Add(validationFailures.Find(a => a.PropertyName == "SexId").ErrorMessage);
            }
            if (validationFailures.Any(a => a.PropertyName == "GradeId"))
            {
                this.GradeIdErrorMessages.Add(validationFailures.Find(a => a.PropertyName == "GradeId").ErrorMessage);
            }
            if (validationFailures.Any(a => a.PropertyName == "PhoneNumber"))
            {
                this.PhoneNumberErrorMessages.Add(validationFailures.Find(a => a.PropertyName == "PhoneNumber").ErrorMessage);
            }
        }
    }
    public bool Success { get; set; }
    public List<string> UsernameErrorMessages { get; set; } = new List<string>();
    public List<string> EmailErrorMessages { get; set; } = new List<string>();
    public List<string> PasswordErrorMessages { get; set; } = new List<string>();
    public List<string> SexIdErrorMessages { get; set; } = new List<string>();
    public List<string> GradeIdErrorMessages { get; set; } = new List<string>();
    public List<string> PhoneNumberErrorMessages { get; set; } = new List<string>();
}