using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeklifPanel.Entity
{
    public class Log : BaseEntity
    {
        public string UserEmail { get; set; }
        public DateTime DateOfLogin { get; set; }
    }
}
