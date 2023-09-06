using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeklifPanel.Entity
{
    public class Iban : BaseEntity
    {
        public int CompanyId { get; set; }
        public string Title { get; set; }
        public string IbanNumber { get; set; }
    }
}
