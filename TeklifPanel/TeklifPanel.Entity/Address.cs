using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeklifPanel.Entity
{
    public class Address : BaseEntity
    {
        public string Name { get; set; }
        public string OpenAddress { get; set; }
        public string AddressDetails { get; set; }

    }
}
