using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Results
{
    public class FindStudentTitleResult
    {
        public string Result { get; set; }
        public bool Success { get; set; }
        public string StudentIdErrorMessage { get; set; }
        public FindStudentTitleResult(Language lang, bool success, string studentIdErrorMessage, string result)
        {
            this.Success = success;
            this.StudentIdErrorMessage = studentIdErrorMessage;
            this.Result = result;
            if (lang == Language.Persian)
            {
                if (studentIdErrorMessage == "invalid-userid")
                {
                    this.StudentIdErrorMessage = "شناسه دانش آموزی مورد نظر نا معتبر است";
                }
            }
            else if (lang == Language.English)
            {
                if (studentIdErrorMessage == "invalid-userid")
                {
                    this.StudentIdErrorMessage = "student id is not valid";
                }
            }
        }
    }
}
