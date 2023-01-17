using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Dto.Models;
using FluentValidation;
using Business.Helpers;
using Entity.Models;

namespace Business.Validation;
public class ChangePasswordDtoValidator : AbstractValidator<ChangePasswordDto>
{
    public ChangePasswordDtoValidator(User user, List<string> hashedPasswords)
    {
        RuleFor(a=> a.UserId).Must((e) => {
            return user != null && user.Id == e;
        }).WithMessage("invalid-userId");
        RuleFor(a=> a.CurrentPassword).Must((e) =>{
            return user != null && user.Password == Helper.ComputeSHA256Hash(e);
        }).WithMessage("invalid-currentPassword");
        RuleFor(x => x.NewPassword).Must(Helper.IsPasswordValid).WithMessage("invalid-newPassword");
        RuleFor(x => x.NewPassword).Must((a) => !IsNewPasswordDuplicate(a,user.Password, hashedPasswords)).WithMessage("duplicate-newPassword");

    }
    
    
    private bool IsNewPasswordDuplicate(string newPassword,string currentHashedPassword,List<string> hashedPasswords)
    {
        if (Helper.ComputeSHA256Hash(newPassword) == currentHashedPassword){
            return true;
        }
        return hashedPasswords.Any(a => a == Helper.ComputeSHA256Hash(newPassword));
    }
   
}