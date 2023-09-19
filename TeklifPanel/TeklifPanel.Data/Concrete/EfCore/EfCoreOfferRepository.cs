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
    public class EfCoreOfferRepository : EfCoreGenericRepository<Offer>, IOfferRepository
    {
        public EfCoreOfferRepository(TeklifPanelContext _dbContext) : base(_dbContext) { }
        private TeklifPanelContext context
        {
            get { return _dbContext as TeklifPanelContext; }
        }

        public async Task<List<Offer>> GetCompanyOffersAsync(int companyId)
        {
            try
            {
                var offerList = await context.Offers
                    .Where(o => o.CompanyId == companyId)
                    .Include(o => o.Company)
                    .Include(o => o.CustomerContact)
                    .Include(o => o.Customer)
                    .Include(o => o.User)
                    .ToListAsync();
                return offerList;

            }
            catch (Exception e)
            {

                throw;
            }

        }
    }
}
