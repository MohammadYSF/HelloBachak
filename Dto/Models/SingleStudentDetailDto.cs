using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Models
{
    public   class SingleStudentDetailDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string GradeTitle { get; set; }
        public string SexTitle { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string RegisterDateString { get; set; }
    }
}
