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
    public class EfCoreIbanRepository : EfCoreGenericRepository<Iban>, IIbanRepository
    {
        public EfCoreIbanRepository(TeklifPanelContext _dbContext) : base(_dbContext) { }
        private TeklifPanelContext context
        {
            get {  return _dbContext as TeklifPanelContext; }
        }

        public async Task<ICollection<Iban>> GetIbansByCompanyAsync(int companyId)
        {
            var ibans = await context.Ibans.Where(i => i.CompanyId == companyId).ToListAsync();
            
            return ibans != null ? ibans : new List<Iban>();
        }
    }
}
