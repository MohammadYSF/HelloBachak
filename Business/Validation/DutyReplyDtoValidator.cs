using Dto.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation
{
    public class DutyReplyDtoValidator : AbstractValidator<DutyReplyDto>
    {
        public DutyReplyDtoValidator(List<int> dutyIds)
        {
            RuleFor(x => x.DutyId).Must((a) => IsDutyIdValid(a , dutyIds)).WithMessage("invalid-dutyId");
        }
        private bool IsDutyIdValid(int dutyId, List<int> dutyIds)
        {
            return dutyIds.Contains(dutyId);
        }
    }
}
