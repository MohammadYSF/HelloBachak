using System;

namespace Entity.Models;

public class Duty
{
    public Duty()
    {
        
    }
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime ArrangedDate { get; set; }
    public DateTime CreationDate { get; set; }
    public bool IsActive { get; set; }
    public int LessonId { get; set; }
    public int ConsultantId { get; set; }
    public int StudentId { get; set; }
    public int? OlderDutyId { get; set; } = null;
    public virtual Entity.Models.Duty? OlderDuty { get; set; }
    public virtual Lesson Lesson { get; set; }
    public virtual DutyReply DutyReply { get; set; }
    public virtual Entity.Models.Duty? NewDuty{get;set;}

    public virtual User Consultant { get; set; }
    public virtual User Student { get; set; }
}
