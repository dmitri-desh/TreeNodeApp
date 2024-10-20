using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TreeNodeApp.API.ExceptionService;
using TreeNodeApp.Application.DTOs;
using TreeNodeApp.Application.Interfaces;
using TreeNodeApp.Core.Entities;
using TreeNodeApp.Core.Exceptions;
using TreeNodeApp.Infrastructure.Interfaces;

namespace TreeNodeApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodesController : ControllerBase
    {
        private readonly INodeService _nodeService;
        private readonly IExceptionService _exceptionService;

        public NodesController(INodeService nodeService, IExceptionService exceptionService)
        {
            _nodeService = nodeService;
            _exceptionService = exceptionService;
            
        }

        [HttpGet("tree/{treeId}")]
        public async Task<ActionResult<IEnumerable<NodeDto>>> GetNodesByTreeId(int treeId)
        {
            var nodes = await _nodeService.GetNodesByTreeIdAsync(treeId);

            return Ok(nodes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NodeDto>> GetById(int id)
        {
            var node = await _nodeService.GetByIdAsync(id);

            if (node == null)
                return NotFound();

            return Ok(node);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNode(CreateNodeDto nodeDto)
        {           
            await _nodeService.AddAsync(nodeDto);
           
            return CreatedAtAction(nameof(GetById), new { id = nodeDto.Id }, nodeDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateNode(UpdateNodeDto nodeDto)
        {
            await _nodeService.UpdateAsync(nodeDto);
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNode(int id)
        {
            await _nodeService.DeleteAsync(id);
           
            return NoContent();
        }
    }
}
