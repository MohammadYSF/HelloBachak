namespace Entity.Models
{
    public class TaskReply
    {
        public int TaskId { get; set; }
        public bool IsSucceed { get; set; }
        public bool IsFailed { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public int UserId { get; set; }
        public virtual Task Task { get; set; } = new Task();
    }
}