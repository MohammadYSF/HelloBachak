namespace Entity.Models;

public class Task
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime ArrangedDate { get; set; }
    public DateTime CreationDate { get; set; }
    public bool IsActive { get; set; }
    public int LessonId { get; set; }
    public int ConsultantId { get; set; }
    public int StudentId { get; set; }
    public int OlderTaskId { get; set; }
    public virtual Task OlderTask { get; set; } = new Task();
    public virtual Lesson Lesson { get; set; } = new Lesson();
    public virtual TaskReply TaskReply { get; set; } = new TaskReply();
    public virtual Task NewTask{get;set;} = new Task();
}
