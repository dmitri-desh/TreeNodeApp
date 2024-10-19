using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNodeApp.Application.DTOs;

namespace TreeNodeApp.Application.Interfaces
{
    public interface INodeService
    {
        Task<IEnumerable<NodeDto>> GetNodesByTreeIdAsync(int treeId);
        Task<NodeDto> GetByIdAsync(int id);
        Task AddAsync(CreateNodeDto nodeDto);
        Task UpdateAsync(UpdateNodeDto nodeDto);
        Task DeleteAsync(int id);
    }
}
