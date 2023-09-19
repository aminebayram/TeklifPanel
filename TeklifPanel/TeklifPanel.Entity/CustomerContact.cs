using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeklifPanel.Entity
{
    public class CustomerContact : BaseEntity
    {
        public CustomerContact()
        {
            Offers = new List<Offer>();
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string Phone { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public List<Offer> Offers { get; set; }
        public int CompanyId { get; set; }
    }
}
