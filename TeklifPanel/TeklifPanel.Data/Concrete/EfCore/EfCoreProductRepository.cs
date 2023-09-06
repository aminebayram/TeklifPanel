using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TeklifPanel.Data.Abstract;
using TeklifPanel.Entity;

namespace TeklifPanel.Data.Concrete.EfCore
{
    public class EfCoreProductRepository : EfCoreGenericRepository<Product>, IProductRepository
    {
        public EfCoreProductRepository(TeklifPanelContext _dbContext) : base(_dbContext) { }
        private TeklifPanelContext context
        {
            get { return _dbContext as TeklifPanelContext; }
        }

        public async Task<List<Product>> GetCompanyProductsAsync(int companyId)
        {
            var productList = await context.Products
                .Where(p => p.CompanyId == companyId)
                .Include(p => p.ProductImages)
                .ToListAsync();
            return productList;
        }

        public async Task<List<Product>> GetProductsByCategoryAsync(int companyId, int categoryId)
        {
            var productList = await context.Products
                .Where(p => p.CompanyId == companyId && p.CategoryId == categoryId)
                .Include(p => p.ProductImages)
                .ToListAsync();
            return productList;
        }
    }
}
