using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Results
{
    public class ChangeConsultantResult
    {
        public ChangeConsultantResult(Language lang , bool isSuccess,string studentIdError="",string consultantIdError = "" )
        {
            this.IsSuccess = isSuccess;
            if (lang == Language.English)
            {
                if (studentIdError == "invalid-studentid")
                {
                    this.StudentIdErrorMessage = "student id is invalid";
                }
                if (consultantIdError == "invalid-consultantid")
                {
                    this.ConsultantIdErrorMessage = "consultant id is invalid";
                }
            }
            else
            {
                if (studentIdError == "invalid-studentid")
                {
                    this.StudentIdErrorMessage = "شناسه دانش آموز نامعتبر است";
                }
                if (consultantIdError == "invalid-consultantid")
                {
                    this.ConsultantIdErrorMessage = "شناسه مشاور نامعتبر است";
                }
            }
        }
        public bool IsSuccess { get; set; }
        public string StudentIdErrorMessage { get; set; }
        public string ConsultantIdErrorMessage { get; set; }
    }
}
