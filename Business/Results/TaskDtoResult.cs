namespace Business.Results;

public class DutyDtoResult
{
    public DutyDtoResult(DutyDtoValidationResult validationResult, Language lang)
    {
        this.Success = validationResult.Success;
        if (lang == Language.English)
        {
            //title
            
             if (validationResult.TitleErrorMessage.Contains("invalid-title"))
            {
                this.TitleErrorMessage = "title is not valid";

            }            
            // ///////////lesson Id
            if (validationResult.LessonIdErrorMessage.Contains("invalid-lessonId"))
            {
                this.LessonIdErrorMessage = "lessonId is not valid";

            }
           
            
            // ///////// student id
            if (validationResult.StudentIdErrorMessage.Contains("invalid-studentId"))
            {
                this.StudentIdErrorMessage = "studentId is not valid";
            }
            // consultant id
            if (validationResult.ConsultantIdErrorMessage.Contains("invalid-consultantId"))
            {
                this.ConsultantIdErrorMessage = "consultantId is not valid";
            }
            //older duty id
            if (validationResult.OlderDutyIdErrorMessage.Contains("invalid-olderDutyId")){
                this.OlderDutyIdErrorMessage = "olderDutyId is not valid";
            }
            //arranged date
            if (validationResult.ArrangedDateErrorMessage.Contains("invalid-arrangedDate"))
            {
                this.ArrangedDateErrorMessage = "arrangedDate is not valid";
            }

        }
        else if (lang == Language.Persian)
        {
            //عنوان وظیفه
             if (validationResult.TitleErrorMessage.Contains("invalid-title"))
            {
                this.TitleErrorMessage = "عنوان وظیفه نامعتبر است";

            }
            
            // ///////////درس 
             if (validationResult.LessonIdErrorMessage.Contains("invalid-lessonId"))
            {
                this.LessonIdErrorMessage = "درس نامعتبر است";

            }
            
            // ///////// دانش آموز
            if (validationResult.StudentIdErrorMessage.Contains("invalid-studentId"))
            {
                this.StudentIdErrorMessage = "دانش آموز وارد شده نامعتبر است";
            }
            // مشاور
            if (validationResult.ConsultantIdErrorMessage.Contains("invalid-consultantId"))
            {
                this.ConsultantIdErrorMessage = "مشاور وارد شده نامعتبر است";
            }
              // وظیلفه قبلی
            if (validationResult.OlderDutyIdErrorMessage.Contains("invalid-olderDutyId"))
            {
                this.OlderDutyIdErrorMessage = "وظیفه قبلی وارد شده نامعتبر است";
            }
               //تاریخ تنظیم شده
            if (validationResult.ArrangedDateErrorMessage.Contains("invalid-arrangedDate"))
            {
                this.ArrangedDateErrorMessage = "تاریخ تنظیم شده وارد شده نامعتبر است";
            }
        }
    }
    public bool Success { get; set; }
    public string TitleErrorMessage { get; set; } = "";
    public string LessonIdErrorMessage { get; set; } = "";
    public string StudentIdErrorMessage { get; set; } = "";
    public string ConsultantIdErrorMessage { get; set; } = "";
    public string OlderDutyIdErrorMessage { get; set; } = "";
    public string ArrangedDateErrorMessage { get; set; } = "";
}

