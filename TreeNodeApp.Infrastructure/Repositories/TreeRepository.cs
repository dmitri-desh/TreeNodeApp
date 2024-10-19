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
    public class TreeRepository : ITreeRepository
    {
        private readonly ApplicationDbContext _context;

        public TreeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tree>> GetAllAsync()
        {
            return await _context.Trees.Include(t => t.Nodes).ToListAsync();
        }

        public async Task<Tree> GetByIdAsync(int id)
        {
            return await _context.Trees.Include(t => t.Nodes).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddAsync(Tree tree)
        {
            _context.Trees.Add(tree);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tree tree)
        {
            _context.Trees.Update(tree);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Tree tree)
        {
            _context.Trees.Remove(tree);
            await _context.SaveChangesAsync();
        }
    }
}
