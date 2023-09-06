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
    public class ContactPersonManager : IContactPersonService
    {
        private readonly IContactPersonRepository _contactPersonRepository;

        public ContactPersonManager(IContactPersonRepository contactPersonRepository)
        {
            _contactPersonRepository = contactPersonRepository;
        }

        public void Create(CustomerContact entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateAsync(CustomerContact entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(CustomerContact entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(CustomerContact entity)
        {
           return await _contactPersonRepository.DeleteAsync(entity);
        }

        public CustomerContact GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerContact> GetByIdAsync(int id)
        {
            return await _contactPersonRepository.GetByIdAsync(id);
        }

        public Task<ICollection<CustomerContact>> GetManyAsync(Expression<Func<CustomerContact, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Update(CustomerContact entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(CustomerContact entity)
        {
            return await _contactPersonRepository.UpdateAsync(entity);
        }

        Task<ICollection<CustomerContact>> IService<CustomerContact>.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<CustomerContact> IService<CustomerContact>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
