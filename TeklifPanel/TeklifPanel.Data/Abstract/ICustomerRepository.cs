using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeklifPanel.Entity;

namespace TeklifPanel.Data.Abstract
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<ICollection<Customer>> GetCompanyByCustomersAsync(int companyId);
        Task<Customer> GetCustomerAsync(int customerId);
        Task<bool> UpdateCustomerAsync(Customer customer);
        Task<bool> DeleteCustomerAsync(int customerId);

    }
}
