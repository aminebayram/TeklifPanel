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

        public async Task<bool> DeleteCategoryAsync(int companyd)
        {
            var category = await context.Categories
                .Include(c => c.Products)
                .SingleOrDefaultAsync(c => c.Id == companyd);
            context.Products.RemoveRange(category.Products);
            context.Remove(category);
            var result = await context.SaveChangesAsync();
            return result > 0 ? true : false;
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
