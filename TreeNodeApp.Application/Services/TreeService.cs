using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNodeApp.Application.DTOs;
using TreeNodeApp.Application.Interfaces;
using TreeNodeApp.Core.Entities;
using TreeNodeApp.Core.Exceptions;
using TreeNodeApp.Infrastructure.Interfaces;

namespace TreeNodeApp.Application.Services
{
    public class TreeService : ITreeService
    {
        private readonly ITreeRepository _treeRepository;
        private readonly IMapper _mapper;

        public TreeService(ITreeRepository treeRepository, IMapper mapper)
        {
            _treeRepository = treeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TreeDto>> GetAllAsync()
        {
            var trees = await _treeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TreeDto>>(trees);
        }

        public async Task<TreeDto> GetByIdAsync(int id)
        {
            var tree = await _treeRepository.GetByIdAsync(id);
            return _mapper.Map<TreeDto>(tree);
        }

        public async Task AddAsync(CreateTreeDto treeDto)
        {
            var tree = _mapper.Map<Tree>(treeDto);
            await _treeRepository.AddAsync(tree);
        }

        public async Task UpdateAsync(TreeDto treeDto)
        {
            var tree = _mapper.Map<Tree>(treeDto);
            await _treeRepository.UpdateAsync(tree);
        }

        public async Task DeleteAsync(int id)
        {
            var tree = await _treeRepository.GetByIdAsync(id);

            await _treeRepository.DeleteAsync(tree);
        }
    }
}
