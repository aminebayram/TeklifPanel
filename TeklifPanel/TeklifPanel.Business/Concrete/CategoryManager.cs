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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Create(Category entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateAsync(Category entity)
        {
            return await _categoryRepository.CreateAsync(entity);
        }

        public void Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(Category entity)
        {
            return await _categoryRepository.DeleteAsync(entity);
        }

        public async Task<bool> DeleteCategoryAsync(int companyd)
        {
            return await _categoryRepository.DeleteCategoryAsync(companyd);
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public async Task<List<Category>> GetCategoriesAsync(int companyd)
        {
            return await _categoryRepository.GetCategoriesAsync(companyd);
        }

        public Task<ICollection<Category>> GetManyAsync(Expression<Func<Category, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(Category entity)
        {
            return await _categoryRepository.UpdateAsync(entity);
        }

        Task<ICollection<Category>> IService<Category>.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<Category> IService<Category>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
