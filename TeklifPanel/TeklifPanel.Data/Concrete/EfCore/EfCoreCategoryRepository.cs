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
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category>, ICategoryRepository
    {
        public EfCoreCategoryRepository(TeklifPanelContext _dbContext) : base(_dbContext) { }
        private TeklifPanelContext context
        {
            get { return _dbContext as TeklifPanelContext; }
        }

        public async Task<List<Category>> GetCategoriesAsync(int companyd)
        {
            var categories = await context.Categories
                .Where(c => c.CompanyId == companyd)
                .ToListAsync();
            return categories;
        }
    }
}
