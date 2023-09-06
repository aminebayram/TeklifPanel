using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeklifPanel.Entity;

namespace TeklifPanel.Data.Abstract
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task<Company> GetLastCompany();
        Task<Company> GetCompanyByIdAsync(int id);

    }
}
