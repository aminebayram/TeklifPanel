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
    public class CompanyManager : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyManager(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public void Create(Company entity)
        {
            _companyRepository.Create(entity);
        }

        public void Delete(Company entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Company>> GetAll()
        {
            return await _companyRepository.GetAll();
        }

        public Task<ICollection<Company>> GetManyAsync(Expression<Func<Company, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Company GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Company> GetByIdAsync(int id)
        {
            return _companyRepository.GetByIdAsync(id);
        }

        public async Task<Company> GetLastCompany()
        {
            return await _companyRepository.GetLastCompany();
        }

        public void Update(Company entity)
        {
            throw new NotImplementedException();
        }

        Task<Company> IService<Company>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateAsync(Company entity)
        {
            return await _companyRepository.CreateAsync(entity);
        }

        public async Task<bool> UpdateAsync(Company entity)
        {
            return await _companyRepository.UpdateAsync(entity);
        }

        public Task<bool> DeleteAsync(Company entity)
        {
            return _companyRepository.DeleteAsync(entity);
        }

        public async Task<Company> GetCompanyByIdAsync(int id)
        {
            return await _companyRepository.GetCompanyByIdAsync(id);
        }
    }
}
