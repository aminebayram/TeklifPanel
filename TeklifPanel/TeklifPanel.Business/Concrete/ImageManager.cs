using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TeklifPanel.Business.Abstract;
using TeklifPanel.Entity;

namespace TeklifPanel.Business.Concrete
{
    public class ImageManager : IImageService
    {
        public void Create(ProductImage entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateAsync(ProductImage entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(ProductImage entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(ProductImage entity)
        {
            throw new NotImplementedException();
        }

        public ProductImage GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductImage> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ProductImage>> GetManyAsync(Expression<Func<ProductImage, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductImage entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(ProductImage entity)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<ProductImage>> IService<ProductImage>.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<ProductImage> IService<ProductImage>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
