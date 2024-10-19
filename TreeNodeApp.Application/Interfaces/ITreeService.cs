using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNodeApp.Application.DTOs;

namespace TreeNodeApp.Application.Interfaces
{
    public interface ITreeService
    {
        Task<IEnumerable<TreeDto>> GetAllAsync();
        Task<TreeDto> GetByIdAsync(int id);
        Task AddAsync(CreateTreeDto treeDto);
        Task UpdateAsync(TreeDto treeDto);
        Task DeleteAsync(int id);
    }
}
