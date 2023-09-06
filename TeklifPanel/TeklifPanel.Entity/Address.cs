using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeklifPanel.Entity
{
    public class Address : BaseEntity
    {
        public Address()
        {
            Offers = new List<Offer>();
        }
        public string Name { get; set; }
        public string OpenAddress { get; set; }
        public string AddressDetails { get; set; }
        public int CompanyId { get; set; }
        public List<Offer> Offers { get; set; }
    }
}
