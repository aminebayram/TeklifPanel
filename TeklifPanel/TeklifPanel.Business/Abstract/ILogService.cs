using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeklifPanel.Entity;

namespace TeklifPanel.Business.Abstract
{
    public interface ILogService : IService<Log>
    {
        Task<List<Log>> GetCompanyLogsAsync(int companyId);
    }
}
