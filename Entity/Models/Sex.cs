using System.Collections;

namespace Entity.Models;

public class Sex
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; }
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
