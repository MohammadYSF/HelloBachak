using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Entity.Models;

public class Lesson
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; }
    public virtual ICollection<Entity.Models.Duty> Duties { get; set; }

}
