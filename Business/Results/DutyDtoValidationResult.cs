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
public class DutyDtoValidationResult
{
    
    public DutyDtoValidationResult(ValidationResult validationResult)
    {
        var validationFailures = validationResult.Errors;
        this.Success = validationResult.IsValid;
        if (!validationResult.IsValid)
        {

            this.Success = false;
            if (validationFailures.Any(a => a.PropertyName == "Title"))
            {
                this.TitleErrorMessage.Add(validationFailures.Find(a => a.PropertyName == "Title").ErrorMessage);
            }
            if (validationFailures.Any(a => a.PropertyName == "LessonId"))
            {
                this.LessonIdErrorMessage.Add(validationFailures.Find(a => a.PropertyName == "LessonId").ErrorMessage);
            }
            if (validationFailures.Any(a => a.PropertyName == "StudentId"))
            {
                this.StudentIdErrorMessage.Add(validationFailures.Find(a => a.PropertyName == "StudentId").ErrorMessage);
            }
            if (validationFailures.Any(a => a.PropertyName == "ConsultantId"))
            {
                this.ConsultantIdErrorMessage.Add(validationFailures.Find(a => a.PropertyName == "ConsultantId").ErrorMessage);
            }
            if (validationFailures.Any(a => a.PropertyName == "OlderDutyId"))
            {
                this.OlderDutyIdErrorMessage.Add(validationFailures.Find(a => a.PropertyName == "OlderDutyId").ErrorMessage);
            }
            if (validationFailures.Any(a => a.PropertyName == "ArrangedDate"))
            {
                this.ArrangedDateErrorMessage.Add(validationFailures.Find(a => a.PropertyName == "ArrangedDate").ErrorMessage);
            }
           
        }
    }
    public bool Success { get; set; }
    public List<string> TitleErrorMessage { get; set; } = new List<string>();
    public List<string> StudentIdErrorMessage { get; set; } = new List<string>();
    public List<string> ConsultantIdErrorMessage { get; set; } = new List<string>();
    public List<string> LessonIdErrorMessage { get; set; } = new List<string>();
    public List<string> OlderDutyIdErrorMessage { get; set; } = new List<string>();
    public List<string> ArrangedDateErrorMessage { get; set; } = new List<string>();
}