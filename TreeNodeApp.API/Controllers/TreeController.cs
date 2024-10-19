using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TreeNodeApp.Application.DTOs;
using TreeNodeApp.Application.Interfaces;

namespace TreeNodeApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreeController : ControllerBase
    {
        private readonly ITreeService _treeService;

        public TreeController(ITreeService treeService)
        {
            _treeService = treeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TreeDto>>> GetAllTrees()
        {
            var trees = await _treeService.GetAllAsync();
            return Ok(trees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TreeDto>> GetById(int id)
        {
            var tree = await _treeService.GetByIdAsync(id);
            if (tree == null)
                return NotFound();
            return Ok(tree);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTree(CreateTreeDto treeDto)
        {
            await _treeService.AddAsync(treeDto);
            return CreatedAtAction(nameof(GetById), new { id = treeDto.Id }, treeDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTree(TreeDto treeDto)
        {
            await _treeService.UpdateAsync(treeDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTree(int id)
        {
            await _treeService.DeleteAsync(id);
            return NoContent();
        }
    }
}
