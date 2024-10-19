using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNodeApp.Application.Interfaces;
using TreeNodeApp.Core.Entities;
using TreeNodeApp.Infrastructure.Interfaces;

namespace TreeNodeApp.Application.Services
{
    public class ExceptionLogService : IExceptionLogService
    {
        private readonly IExceptionLogRepository _exceptionLogRepository;

        public ExceptionLogService(IExceptionLogRepository exceptionLogRepository)
        {
            _exceptionLogRepository = exceptionLogRepository;
        }

        public async Task<IEnumerable<ExceptionLog>> GetAllAsync()
        {
            return await _exceptionLogRepository.GetAllAsync();
        }

        public async Task<ExceptionLog> GetByIdAsync(long id)
        {
            return await _exceptionLogRepository.GetByIdAsync(id);
        }
    }
}
