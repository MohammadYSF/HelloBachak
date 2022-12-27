namespace Entity.Models;

public class Lesson
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; }
    public virtual ICollection<Task> Tasks { get; set; }

}
