using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Results
{
    public class UpdateLessonResult
    {
        public UpdateLessonResult(Language lang,bool isSuccess,string lessonIdError="",string lessonTitleError="")
        {
            this.IsSuccess = isSuccess;
            if (lang == Language.English)
            {
                if (this.LessonIdErrorMessage == "invalid-lessonid")
                {
                    this.LessonIdErrorMessage = "lesson id is invalid";
                }
                if (this.LessonTitleErrorMessage == "invalid-title")
                {
                    this.LessonTitleErrorMessage = "lesson title is invalid";
                }
            }
            else
            {
                if (this.LessonIdErrorMessage == "invalid-lessonid")
                {
                    this.LessonIdErrorMessage = "شناسه درس نامعتبر است";
                }
                if (this.LessonTitleErrorMessage == "invalid-title")
                {
                    this.LessonTitleErrorMessage = "عنوان درس نامعتبر است";
                }
            }

        }
        public bool IsSuccess { get; set; }
        public string LessonIdErrorMessage { get; set; }
        public string LessonTitleErrorMessage { get; set; }
    }
}
