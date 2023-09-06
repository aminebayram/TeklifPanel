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
    public class IbanManager : IIbanService
    {
        private readonly IIbanRepository _ibanRepository;

        public IbanManager(IIbanRepository ibanRepository)
        {
            _ibanRepository = ibanRepository;
        }

        public void Create(Iban entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateAsync(Iban entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Iban entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(Iban entity)
        {
            return await _ibanRepository.DeleteAsync(entity);
        }

        public async Task<ICollection<Iban>> GetAll()
        {
            return await _ibanRepository.GetAll();
        }

        public Task<Iban> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Iban> GetByIdAsync(int id)
        {
            return await _ibanRepository.GetByIdAsync(id);
        }

        public async Task<ICollection<Iban>> GetIbansByCompanyAsync(int companyId)
        {
            return await _ibanRepository.GetIbansByCompanyAsync(companyId);
        }

        public Task<ICollection<Iban>> GetManyAsync(Expression<Func<Iban, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Update(Iban entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Iban entity)
        {
            throw new NotImplementedException();
        }
    }
}
