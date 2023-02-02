using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Dto.Models;
using FluentValidation;
using Business.Helpers;
using Entity.Models;

namespace Business.Validation;
public class SendActivationCodeDtoValidator : AbstractValidator<SendActivationCodeDto>
{
    public SendActivationCodeDtoValidator(List<string> userEmails)
    {
        RuleFor(a=> a.Email).Must((e) => {
           return Helper.IsEmailValid(e); 
        }).WithMessage("invalid-email");
        RuleFor(a=> a.Email).Must((e) => {
            return !this.IsEmailNotExists(e , userEmails);
        }).WithMessage("not-found-email");
        
    }
    private bool IsEmailNotExists(string email , List<string> userEmails){
        if (userEmails.Any(a=> a == email) == false){
            return true;
        }
        return false;
    }

}