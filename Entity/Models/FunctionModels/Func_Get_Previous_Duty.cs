using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models.FunctionModels
{
    public class Func_Get_Previous_Duty
    {
        public int Id { get; set; }
        public Nullable<int> OlderDutyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
