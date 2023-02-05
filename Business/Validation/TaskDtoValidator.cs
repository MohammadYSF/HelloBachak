using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Dto.Models;
using FluentValidation;
using Business.Helpers;
namespace Business.Validation;
public class DutyDtoValidator : AbstractValidator<DutyDto>
{
    public DutyDtoValidator(List<int> lessonIds, List<int> studentIds, List<int> consultantIds , List<int> dutyIds)
    {

        RuleFor(x => x.Title).NotEmpty().MaximumLength(200).WithMessage("invalid-title");
        RuleFor(x => x.StudentId).Must((a) => IsStudentIdValid(a, studentIds)).WithMessage("invalid-studentId");
        RuleFor(x => x.ConsultantId).Must((a) => IsConsultantIdValid(a, consultantIds)).WithMessage("invalid-consultantId");
        RuleFor(x=> x.LessonId).Must((a) => IsLessonIdValid(a,lessonIds)).WithMessage("invalid-lessonId");
        RuleFor(x=> x.OlderDutyId).Must((a) => IsOlderDutyIdValid(a , dutyIds)).WithMessage("invalid-olderDutyId");
        RuleFor(x=> x.ArrangedDate).NotEqual(default(DateTime)).WithMessage("invalid-arrangedDate");
    }
    private bool IsLessonIdValid(int lessonId, List<int> lessonIds)
    {
        return lessonIds.Any(a => a == lessonId);
    }
    private bool IsOlderDutyIdValid(int? olderDutyId , List<int> dutyIds){
        if (olderDutyId == null){
            return true;
        }
        return dutyIds.Any(a=> a == olderDutyId);
    }
    private bool IsStudentIdValid(int studentId, List<int> studentIds)
    {
        return studentIds.Any(a => a == studentId);
    }
    private bool IsConsultantIdValid(int consultantId, List<int> consultantIds)
    {
        return consultantIds.Any(a => a == consultantId);
    }


    private bool IsPhoneNumberDuplicate(string phoneNumber, List<string> phoneNumbers)
    {
        return phoneNumbers.Any(a => a == phoneNumber);
    }

    private bool IsEmailDuplicate(string email, List<string> emails)
    {
        return emails.Any(a => a == email);
    }
}