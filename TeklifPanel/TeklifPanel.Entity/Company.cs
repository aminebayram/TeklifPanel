using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeklifPanel.Entity
{
    public class Company 
    {
        public Company()
        {
            Categories = new List<Category>();
            Products = new List<Product>();
            Customers = new List<Customer>();
            Addresses = new List<Address>();
            CompanySettings = new List<CompanySettings>();
            Logs = new List<Log>();
            Users = new List<User>();
            Ibans = new List<Iban>();
            CustomerContacts = new List<CustomerContact>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string Email { get; set; }
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Address> Addresses { get; set; }
        public List<CompanySettings> CompanySettings{ get; set; }
        public List<Log> Logs { get; set; }
        public List<User> Users { get; set; }
        public List<Iban> Ibans { get; set; }
        public List<CustomerContact> CustomerContacts { get; set; }
    }
}
