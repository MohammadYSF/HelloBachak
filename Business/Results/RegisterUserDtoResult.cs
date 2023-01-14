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
public class RegisterUserDtoResult
{
    public RegisterUserDtoResult(ValidationResult validationResult)
    {
        var validationFailures = validationResult.Errors;
        this.Success = validationResult.IsValid;
        if (!validationResult.IsValid)
        {

            this.Success = false;
            if (validationFailures.Any(a => a.PropertyName == "Email"))
            {
                this.EmailErrorMessage = validationFailures.Find(a => a.PropertyName == "Email").ErrorMessage;
            }
            if (validationFailures.Any(a => a.PropertyName == "Password"))
            {
                this.PasswordErrorMessage = validationFailures.Find(a => a.PropertyName == "Password").ErrorMessage;
            }
            if (validationFailures.Any(a => a.PropertyName == "Username"))
            {
                this.UsernameErrorMessage = validationFailures.Find(a => a.PropertyName == "Username").ErrorMessage;
            }
            if (validationFailures.Any(a => a.PropertyName == "SexId"))
            {
                this.SexIdErrorMessage = validationFailures.Find(a => a.PropertyName == "SexId").ErrorMessage;
            }
            if (validationFailures.Any(a => a.PropertyName == "GradeId"))
            {
                this.GradeIdErrorMessage = validationFailures.Find(a => a.PropertyName == "GradeId").ErrorMessage;
            }
            if (validationFailures.Any(a => a.PropertyName == "PhoneNumber"))
            {
                this.PhoneNumberErrorMessage = validationFailures.Find(a=> a.PropertyName == "PhoneNumber").ErrorMessage;
            }
        }
    }
    public bool Success { get; set; }
    public string UsernameErrorMessage { get; set; }
    public string EmailErrorMessage { get; set; }
    public string PasswordErrorMessage { get; set; }
    public string SexIdErrorMessage { get; set; }
    public string GradeIdErrorMessage { get; set; }
    public string PhoneNumberErrorMessage { get; set; }
}