using Dto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Results
{
    public class FindLessonResult
    {
        public FindLessonResult(Language lang , bool isSuccess , string lessonIdErrorMessage , LessonDto result)
        {
            this.IsSuccess = isSuccess;
            if (isSuccess)
                this.Result = result;
            if (lang == Language.English)
            {
                if (lessonIdErrorMessage == "invalid-lessonid")
                    this.LessonIdErrorMessage = "lesson id does is not valid";
            }
            else if (lang == Language.Persian)
            {
                if (lessonIdErrorMessage == "invalid-lessonid")
                    this.LessonIdErrorMessage = "شناسه درس وار شده وجود ندارد";
            }
        }
        public LessonDto Result{ get; set; }
        public bool IsSuccess { get; set; }
        public string LessonIdErrorMessage { get; set; } = "";
    }
}
