using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TeklifPanel.Business.Abstract;
using TeklifPanel.Data.Abstract;
using TeklifPanel.Entity;

namespace TeklifPanel.Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerManager(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Create(Customer entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateAsync(Customer entity)
        {
            return await _customerRepository.CreateAsync(entity);
        }

        public void Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _customerRepository.GetByIdAsync(id);
        }

        public async Task<ICollection<Customer>> GetCompanyByCustomersAsync(int companyId)
        {
           return await _customerRepository.GetCompanyByCustomersAsync(companyId);
        }

        public async Task<Customer> GetCustomerAsync(int customerId)
        {
            return await _customerRepository.GetCustomerAsync(customerId);
        }

        public Task<ICollection<Customer>> GetManyAsync(Expression<Func<Customer, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(Customer entity)
        {
            return await _customerRepository.UpdateAsync(entity);
        }

        public async Task<bool> UpdateCustomerAsync(Customer customer)
        {
            return await _customerRepository.UpdateCustomerAsync(customer);
        }

        Task<ICollection<Customer>> IService<Customer>.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<Customer> IService<Customer>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
