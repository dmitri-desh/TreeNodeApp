using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNodeApp.Core.Entities;

namespace TreeNodeApp.Infrastructure.Interfaces
{
    public interface IExceptionLogRepository
    {
        Task<IEnumerable<ExceptionLog>> GetAllAsync();
        Task<ExceptionLog> GetByIdAsync(long id);
        Task AddAsync(ExceptionLog exceptionLog);
    }
}
