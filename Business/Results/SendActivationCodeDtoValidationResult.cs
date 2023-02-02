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
public class SendActivationCodeDtoValidationResult
{
    
    public SendActivationCodeDtoValidationResult(ValidationResult validationResult)
    {
        var validationFailures = validationResult.Errors;
        this.Success = validationResult.IsValid;
        if (!validationResult.IsValid)
        {

            this.Success = false;
            if (validationFailures.Any(a => a.PropertyName == "Email"))
            {
                this.EmailErrorMessages.AddRange(validationFailures.Where(a => a.PropertyName == "Email").Select(a=> a.ErrorMessage));
            }
            
        }
    }
    public bool Success { get; set; }
    public List<string> EmailErrorMessages { get; set; } = new List<string>();
}