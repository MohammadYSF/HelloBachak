using System;

namespace Entity.Models
{
    public class DutyReply
    {
        public DutyReply()
        {
            
        }
        public int DutyId { get; set; }
        public bool IsSucceed { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual Entity.Models.Duty Duty { get; set; }
    }
}