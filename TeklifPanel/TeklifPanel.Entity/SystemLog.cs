using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeklifPanel.Entity
{
    public class SystemLog : BaseEntity
    {
        public string IP { get; set; }
        public string SourceType { get; set; }
        public int SourceId { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public bool IsRegisted { get; set; }

    }
}
