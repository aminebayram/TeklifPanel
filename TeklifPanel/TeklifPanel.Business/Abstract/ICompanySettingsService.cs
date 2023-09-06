using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeklifPanel.Entity;

namespace TeklifPanel.Business.Abstract
{
    public interface ICompanySettingsService : IService<CompanySettings>
    {
        Task<bool> CreateCompanySettingsAsync(int companyId);
        Task<List<CompanySettings>> GetAllCompanySettingsAsync(int companyId);
        Task<bool> UpdateCompanySettingAsync(List<CompanySettings> settings);

    }
}
