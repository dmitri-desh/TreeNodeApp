using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNodeApp.Application.DTOs;
using TreeNodeApp.Application.Interfaces;
using TreeNodeApp.Core.Entities;
using TreeNodeApp.Infrastructure.Interfaces;

namespace TreeNodeApp.Application.Services
{
    public class NodeService : INodeService
    {
        private readonly INodeRepository _nodeRepository;
        private readonly IMapper _mapper;

        public NodeService(INodeRepository nodeRepository, IMapper mapper)
        {
            _nodeRepository = nodeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NodeDto>> GetNodesByTreeIdAsync(int treeId)
        {
            var nodes = await _nodeRepository.GetNodesByTreeIdAsync(treeId);
            return _mapper.Map<IEnumerable<NodeDto>>(nodes);
        }

        public async Task<NodeDto> GetByIdAsync(int id)
        {
            var node = await _nodeRepository.GetByIdAsync(id);
            return _mapper.Map<NodeDto>(node);
        }

        public async Task AddAsync(CreateNodeDto nodeDto)
        {
            var node = _mapper.Map<Node>(nodeDto);
            await _nodeRepository.AddAsync(node);
        }

        public async Task UpdateAsync(UpdateNodeDto nodeDto)
        {
            var node = _mapper.Map<Node>(nodeDto);
            await _nodeRepository.UpdateAsync(node);
        }

        public async Task DeleteAsync(int id)
        {
            var node = await _nodeRepository.GetByIdAsync(id);

            await _nodeRepository.DeleteAsync(node);
        }
    }
}
