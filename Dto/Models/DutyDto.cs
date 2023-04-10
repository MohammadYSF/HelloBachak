namespace Dto.Models;

public class DutyDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime ArrangedDate { get; set; }
    public bool IsActive { get; set; }
    public int LessonId { get; set; }
    public string LessonTitle { get; set; }
    public string ConsultantTitle { get; set; }
    public string StudentTitle { get; set; }
    public int ConsultantId { get; set; }
    public int StudentId { get; set; }
    public int? OlderDutyId { get; set; }
    public string ArrangedDateString { get; set; }

}
