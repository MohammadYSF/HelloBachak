using Dto.Models;
using FluentValidation;
using Entity.Models;
using Business.Helpers;

namespace Business.Validation;

public class LoginUserDtoValidator : AbstractValidator<LoginUserDto>
{
    public LoginUserDtoValidator(IQueryable<User> users)
    {
        RuleFor(a => a.Email).Must((a) => IsEmailExist(a, users.Select(a => a.Email))).WithMessage("notexist-email");
        RuleFor(a => a).Must(a => IsUserExist(users, a.Email, a.Password)).WithMessage("wrong-password");
    }
    private bool IsUserExist(IQueryable<User> users,string email , string password)
    {
        return users.Any(a => a.Email == email && a.Password == Helper.ComputeSHA256Hash(password));
    }
    private bool IsEmailExist(string email, IQueryable<string> emails) { 
        return emails.Any(a=> a == email); 
    }
}