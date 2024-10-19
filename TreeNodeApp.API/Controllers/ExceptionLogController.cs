using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TreeNodeApp.Application.DTOs;
using TreeNodeApp.Application.Interfaces;
using TreeNodeApp.Core.Entities;
using TreeNodeApp.Infrastructure.Interfaces;

namespace TreeNodeApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExceptionLogController : ControllerBase
    {
        private readonly IExceptionLogService _exceptionLogService;

        public ExceptionLogController(IExceptionLogService exceptionLogService)
        {
            _exceptionLogService = exceptionLogService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExceptionLog>>> GetAll()
        {
            var logs = await _exceptionLogService.GetAllAsync();
            return Ok(logs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExceptionLog>> GetById(long id)
        {
            var log = await _exceptionLogService.GetByIdAsync(id);
            if (log == null)
                return NotFound();
            return Ok(log);
        }
    }
}
