using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeklifPanel.Entity
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
    }
}
