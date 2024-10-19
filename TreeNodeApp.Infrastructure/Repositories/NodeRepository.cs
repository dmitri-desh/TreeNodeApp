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
    public class NodeRepository : INodeRepository
    {
        private readonly ApplicationDbContext _context;

        public NodeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Node>> GetNodesByTreeIdAsync(int treeId)
        {
            return await _context.Nodes.Where(n => n.TreeId == treeId).ToListAsync();
        }

        public async Task<Node> GetByIdAsync(int id)
        {
            return await _context.Nodes.FindAsync(id);
        }

        public async Task AddAsync(Node node)
        {
            _context.Nodes.Add(node);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Node node)
        {
            _context.Nodes.Update(node);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Node node)
        {
            _context.Nodes.Remove(node);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> HasChildNodesAsync(int nodeId)
        {
            return await _context.Nodes.AnyAsync(n => n.ParentId == nodeId);
        }
    }
}
