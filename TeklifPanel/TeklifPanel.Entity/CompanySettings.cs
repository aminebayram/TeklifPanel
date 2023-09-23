using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeklifPanel.Entity
{
    public class CompanySettings : BaseEntity
    {
        public string Parameter { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
    }
}
