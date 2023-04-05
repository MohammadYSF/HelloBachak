using System;

namespace Entity.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
        public short Age { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int SexId { get; set; }
        public int GradeId { get; set; }
      
        public string RefreshToken { get; set; }

        public string ActivationCode { get; set; } = string.Empty;
        public int? ConsultantId { get; set; }
        public virtual Sex Sex { get; set; } = new Sex();
        public virtual Grade Grade { get; set; } = new Grade();
        public virtual Role Role { get; set; } = new Role();
        public virtual ICollection<UserRole> UserRoles { get; set; } 

    }
}