using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Results
{
    public class DutyReplyDtoValidationResult
    {
        public DutyReplyDtoValidationResult(ValidationResult validationResult)
        {

            this.Success = validationResult.IsValid;
            var validationFailures = validationResult.Errors;
            if (!validationResult.IsValid)
            {

                this.Success = false;
                if (validationFailures.Any(a => a.PropertyName == "DutyId"))
                {
                    this.DutyIdErrorMessage.Add(validationFailures.Find(a => a.PropertyName == "DutyId").ErrorMessage);
                }
             

            }
        }
        public bool Success { get; set; }
        public List<string> DutyIdErrorMessage { get; set; } = new List<string>();
    }
}
