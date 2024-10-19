using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNodeApp.Core.Entities;

namespace TreeNodeApp.Infrastructure.Interfaces
{
    public interface ITreeRepository
    {
        Task<IEnumerable<Tree>> GetAllAsync();
        Task<Tree> GetByIdAsync(int id);
        Task AddAsync(Tree tree);
        Task UpdateAsync(Tree tree);
        Task DeleteAsync(Tree tree);
    }
}
