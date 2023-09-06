using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeklifPanel.Entity;

namespace TeklifPanel.Business.Abstract
{
    public interface IIbanService : IService<Iban>
    {
        Task<ICollection<Iban>> GetIbansByCompanyAsync(int companyId);
    }
}
