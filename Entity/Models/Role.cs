using System;
using System.Collections;
using System.Collections.Generic;

namespace Entity.Models;

public class Role
{
    public Role()
    {
        
    }
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; }
    public virtual ICollection<UserRole> UserRoles{ get; set; }
}
