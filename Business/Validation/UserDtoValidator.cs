using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Dto.Models;
using FluentValidation;
using Business.Helpers;
namespace Business.Validation;
public class UserDtoValidator : AbstractValidator<RegisterUserDto>
{
    public UserDtoValidator(List<string> emails, List<string> hashedPasswords, List<int> sexIds, List<int> gradeIds)
    {

        RuleFor(x => x.Username).NotEmpty().MaximumLength(50).MinimumLength(3).Must(IsUsernameValid).WithMessage("invalid");
        RuleFor(x => x.Age).GreaterThan(0).LessThan(130).WithMessage("invalid");
        RuleFor(x => x.Email).Must(IsEmailValid).WithMessage("invalid-syntax");
        RuleFor(x => x.Email).Must((a) => IsEmailDuplicate(a, emails)).WithMessage("duplicate");
        RuleFor(x => x.Password).Must(IsPasswordValid).WithMessage("weak");
        RuleFor(x => x.Password).Must((a) => IsPasswordDuplicate(a, hashedPasswords)).WithMessage("duplicate");
        RuleFor(x => x.SexId).Must(((a) => IsSexIdValid(a, sexIds))).WithMessage("invalid");
        RuleFor(x => x.GradeId).Must((a) => IsGradeIdValid(a, gradeIds)).WithMessage("invalid");
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
    private bool IsUsernameValid(string username)
    {
        var validUsernameRegex = new Regex("^[A-Za-z][A-Za-z0-9]*$");
        return validUsernameRegex.IsMatch(username) && username.Length > 3;
    }
    private bool IsPasswordValid(string password)
    {

        var validPasswordRegex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
        return validPasswordRegex.IsMatch(password) && password.Length <= 100;
        //password conditions : 
        //at least 8 character
        //at least 1 upper
        // at least 1 lower
        // at least 1 special
        //at least 1 digit
        // in the database  , the max size of password is 100 . so we add the condition : 
        // password.lenght <= 100
    }
    private bool IsEmailValid(string email)
    {
        var validEmailRegex = new Regex("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$");
        return validEmailRegex.IsMatch(email);
    }
    private bool IsEmailDuplicate(string email, List<string> emails)
    {
        return emails.Any(a => a == email);
    }
}