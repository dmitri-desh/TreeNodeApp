using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNodeApp.Core.Entities;

namespace TreeNodeApp.Application.Interfaces
{
    public interface IExceptionLogService
    {
        Task<IEnumerable<ExceptionLog>> GetAllAsync();
        Task<ExceptionLog> GetByIdAsync(long id);
    }
}
