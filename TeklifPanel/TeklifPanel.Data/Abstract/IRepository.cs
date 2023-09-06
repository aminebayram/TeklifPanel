using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TeklifPanel.Data.Abstract
{
    public interface IRepository<TEntity>
    {
        TEntity GetById(int id);
        Task<ICollection<TEntity>> GetAll();
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<TEntity> GetByIdAsync(int id);
        Task<ICollection<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> expression);
        Task<bool> CreateAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
    }
}
