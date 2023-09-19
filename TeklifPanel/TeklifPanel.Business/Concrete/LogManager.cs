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
    public class LogManager : ILogService
    {
        private readonly ILogRepository _logRepository;

        public LogManager(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public void Create(Log entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateAsync(Log entity)
        {
            return await _logRepository.CreateAsync(entity);
        }

        public void Delete(Log entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Log entity)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Log>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Log> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Log> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Log>> GetCompanyLogsAsync(int companyId)
        {
            return await _logRepository.GetCompanyLogsAsync(companyId);
        }

        public Task<ICollection<Log>> GetManyAsync(Expression<Func<Log, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Update(Log entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Log entity)
        {
            throw new NotImplementedException();
        }
    }
}
