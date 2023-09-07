using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TeklifPanel.Business.Abstract;
using TeklifPanel.Data.Abstract;
using TeklifPanel.Entity;

namespace TeklifPanel.Business.Concrete
{
    public class ImageManager : IImageService
    {
        private readonly IImageRepository _imageRepository;

        public ImageManager(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

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

        public async Task<bool> DeleteAsync(ProductImage entity)
        {
            return await _imageRepository.DeleteAsync(entity);
        }

        public ProductImage GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductImage> GetByIdAsync(int id)
        {
            return await _imageRepository.GetByIdAsync(id);
        }

        public Task<ICollection<ProductImage>> GetManyAsync(Expression<Func<ProductImage, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductImage entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(ProductImage entity)
        {
            return await _imageRepository.UpdateAsync(entity);
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
