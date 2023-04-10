using Dto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Results
{
    public class ShowDutyDetailResult
    {
        public bool Success { get; set; }
        public Tuple<string,string> UserIdErrorMessage { get; set; } = new Tuple<string, string>("", "");
        public Tuple<string,string> DutyIdErrorMessage { get; set; } = new Tuple<string, string>("","");
        public DutyDto Result { get; set; }
        public ShowDutyDetailResult(Language lang , bool success , string dutyIdErrorMessage , string userIdErrorMessage , DutyDto result)
        {
            
            this.Success = success;
            this.Result = result;
            if (lang == Language.Persian)
            {
                if (dutyIdErrorMessage == "invalid-dutyId")
                {
                    this.DutyIdErrorMessage = new Tuple<string, string>(dutyIdErrorMessage, "شناسه وظیفه نامعتبر است");
                }
                if (userIdErrorMessage == "invalid-userid")
                {
                    this.UserIdErrorMessage = new Tuple<string, string>(userIdErrorMessage, "شناسه کاربری نامعتبر است");
                }
                else if (userIdErrorMessage == "no-access")
                {
                    this.UserIdErrorMessage = new Tuple<string, string>(userIdErrorMessage, "دسترسی ندارید");
                }
            }
            else if (lang == Language.Persian)
            {
                if (dutyIdErrorMessage == "invalid-dutyId")
                {
                    this.DutyIdErrorMessage = new Tuple<string, string>(dutyIdErrorMessage, "duty id is invalid");
                }
                if (userIdErrorMessage == "invalid-userid")
                {
                    this.UserIdErrorMessage = new Tuple<string, string>(userIdErrorMessage, "user id is invalid");
                }
                else if (userIdErrorMessage == "no-access")
                {
                    this.UserIdErrorMessage = new Tuple<string, string>(userIdErrorMessage, "you do not have access to the data");
                }
            }
        }
    }
}
