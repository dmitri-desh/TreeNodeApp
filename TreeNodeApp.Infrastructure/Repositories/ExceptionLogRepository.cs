using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNodeApp.Core.Entities;
using TreeNodeApp.Infrastructure.Data;
using TreeNodeApp.Infrastructure.Interfaces;

namespace TreeNodeApp.Infrastructure.Repositories
{
    public class ExceptionLogRepository : IExceptionLogRepository
    {
        private readonly ApplicationDbContext _context;

        public ExceptionLogRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ExceptionLog>> GetAllAsync()
        {
            return await _context.ExceptionLogs.ToListAsync();
        }

        public async Task<ExceptionLog> GetByIdAsync(long id)
        {
            return await _context.ExceptionLogs.FindAsync(id);
        }

        public async Task AddAsync(ExceptionLog exceptionLog)
        {
            _context.ExceptionLogs.Add(exceptionLog);
            await _context.SaveChangesAsync();
        }
    }
}
