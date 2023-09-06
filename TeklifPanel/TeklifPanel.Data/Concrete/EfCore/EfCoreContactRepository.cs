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
    public class EfCoreContactRepository : EfCoreGenericRepository<CustomerContact>, IContactPersonRepository
    {
        public EfCoreContactRepository(TeklifPanelContext _dbContext) : base(_dbContext) { }
        private TeklifPanelContext context
        {
            get { return _dbContext as TeklifPanelContext; }
        }
    }
}
