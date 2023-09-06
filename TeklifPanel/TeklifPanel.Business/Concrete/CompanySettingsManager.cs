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
    public class CompanySettingsManager : ICompanySettingsService
    {
        private readonly ICompanySettingsRepository _companySettingsRepository;

        public CompanySettingsManager(ICompanySettingsRepository companySettingsRepository)
        {
            _companySettingsRepository = companySettingsRepository;
        }

        public void Create(CompanySettings entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateAsync(CompanySettings entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateCompanySettingsAsync(int companyId)
        {
            return await _companySettingsRepository.CreateCompanySettingsAsync(companyId);
        }

        public void Delete(CompanySettings entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(CompanySettings entity)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<CompanySettings>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<CompanySettings>> GetAllCompanySettingsAsync(int companyId)
        {
            return await _companySettingsRepository.GetAllCompanySettingsAsync(companyId);
        }

        public Task<CompanySettings> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<CompanySettings> GetByIdAsync(int id)
        {
            return await _companySettingsRepository.GetByIdAsync(id);
        }

        public Task<ICollection<CompanySettings>> GetManyAsync(Expression<Func<CompanySettings, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Update(CompanySettings entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(CompanySettings entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateCompanySettingAsync(List<CompanySettings> settings)
        {
            return await _companySettingsRepository.UpdateCompanySettingAsync(settings);
        }
    }
}
