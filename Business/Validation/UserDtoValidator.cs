using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Dto.Models;
using FluentValidation;
using Business.Helpers;

namespace Business.Validation;
public class UserDtoValidator : AbstractValidator<RegisterUserDto>
{
    public UserDtoValidator(List<string> emails, List<string> hashedPasswords, List<int> sexIds, List<int> gradeIds, List<string> usernames, List<string> phoneNumbers)
    {

        RuleFor(x => x.Username).NotEmpty().Must(Helper.IsUsernameValid).WithMessage("invalid-username");
        RuleFor(x => x.Username).Must((a) => !IsUsernameDuplicate(a, usernames)).WithMessage("duplicate-username");
        RuleFor(x => (int)x.Age).GreaterThan(0).LessThan(130).WithMessage("invalid-age");
        RuleFor(x => x.Email).Must(Helper.IsEmailValid).WithMessage("invalid-email");
        RuleFor(x => x.Email).Must((a) => !IsEmailDuplicate(a, emails)).WithMessage("duplicate-email");
        RuleFor(x => x.Password).Must(Helper.IsPasswordValid).WithMessage("invalid-password");
        RuleFor(x => x.Password).Must((a) => !IsPasswordDuplicate(a, hashedPasswords)).WithMessage("duplicate-password");
        RuleFor(x => x.SexId).Must(((a) => IsSexIdValid(a, sexIds))).WithMessage("invalid-sexId");
        RuleFor(x => x.GradeId).Must((a) => IsGradeIdValid(a, gradeIds)).WithMessage("invalid-gradeId");
        RuleFor(x => x.PhoneNumber).Must(Helper.IsPhoneNumberValid).WithMessage("invalid-phoneNumber");
        RuleFor(x => x.PhoneNumber).Must((a) => !IsPhoneNumberDuplicate(a, phoneNumbers)).WithMessage("duplicate-phoneNumber");
    }
    private bool IsGradeIdValid(int gradeId, List<int> gradeIds)
    {
        return gradeIds.Any(a => a == gradeId);
    }
    private bool IsSexIdValid(int sexId, List<int> sexIds)
    {
        return sexIds.Any(a => a == sexId);
    }

    private bool IsPasswordDuplicate(string password, List<string> hashedPasswords)
    {
        return hashedPasswords.Any(a => a == Helper.ComputeSHA256Hash(password));
    }

    private bool IsUsernameDuplicate(string username, List<string> usernames)
    {
        return usernames.Any(a => a == username);
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
