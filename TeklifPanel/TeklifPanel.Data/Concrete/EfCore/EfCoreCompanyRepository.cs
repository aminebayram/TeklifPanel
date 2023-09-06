using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeklifPanel.Data.Abstract;
using TeklifPanel.Entity;

namespace TeklifPanel.Data.Concrete.EfCore
{
    public class EfCoreCompanyRepository : EfCoreGenericRepository<Company>, ICompanyRepository
    {
        public EfCoreCompanyRepository(TeklifPanelContext _dbContext) : base(_dbContext) { }
        private TeklifPanelContext context
        {
            get { return _dbContext as TeklifPanelContext; }
        }

        public async Task<Company> GetCompanyByIdAsync(int id)
        {
            var company = await context.Companies.Where(c => c.Id == id)
                .Include(c => c.Ibans)
                .FirstOrDefaultAsync();
            return company;
        }

        public async Task<Company> GetLastCompany()
        {
            var company = await context.Companies.OrderByDescending(c => c.Id).FirstOrDefaultAsync();

            return company;

        }
    }
}
