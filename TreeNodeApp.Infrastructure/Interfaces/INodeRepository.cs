using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNodeApp.Core.Entities;

namespace TreeNodeApp.Infrastructure.Interfaces
{
    public interface INodeRepository
    {
        Task<IEnumerable<Node>> GetNodesByTreeIdAsync(int treeId);
        Task<Node> GetByIdAsync(int id);
        Task AddAsync(Node node);
        Task UpdateAsync(Node node);
        Task DeleteAsync(Node node);
        Task<bool> HasChildNodesAsync(int nodeId);
    }
}
