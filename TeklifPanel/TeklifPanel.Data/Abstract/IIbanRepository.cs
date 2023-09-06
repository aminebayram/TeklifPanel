using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeklifPanel.Entity;

namespace TeklifPanel.Data.Abstract
{
    public interface IIbanRepository : IRepository<Iban>
    {
        Task<ICollection<Iban>> GetIbansByCompanyAsync(int companyId);
    }
}
