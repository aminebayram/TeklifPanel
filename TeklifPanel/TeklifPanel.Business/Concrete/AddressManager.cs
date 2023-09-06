using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TeklifPanel.Business.Abstract;
using TeklifPanel.Entity;

namespace TeklifPanel.Business.Concrete
{
    public class AddressManager : IAddressService
    {
        public void Create(Address entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Address entity)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Address>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Address>> GetManyAsync(Expression<Func<Address, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Address GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Address> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Address entity)
        {
            throw new NotImplementedException();
        }

        Task<Address> IService<Address>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateAsync(Address entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Address entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Address entity)
        {
            throw new NotImplementedException();
        }
    }
}
