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
    public class EfCoreLogRepository : EfCoreGenericRepository<Log>, ILogRepository
    {
        public EfCoreLogRepository(TeklifPanelContext _dbContext) : base(_dbContext) { }
        private TeklifPanelContext context
        {
            get { return _dbContext as TeklifPanelContext; }
        }

        public async Task<List<Log>> GetCompanyLogsAsync(int companyId)
        {
            try
            {
                var logList = await context.Logs.Where(l => l.CompanyId == companyId).ToListAsync();
                return logList;
            }
            catch (Exception e)
            {

                throw;
            }

        }
    }
}
