using Microsoft.AspNetCore.Mvc;
using TwinSim.Domain.Models;
using TwinSim.Domain.Interfaces;

namespace TwinSim.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TwinController : ControllerBase
    {
        private readonly ITwinService _twinService;

        public TwinController(ITwinService twinService)
        {
            _twinService = twinService;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_twinService.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var twin = _twinService.GetById(id);
            return twin is null ? NotFound() : Ok(twin);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TwinObject obj)
        {
            var createdObject = _twinService.Create(obj);
            return CreatedAtAction(nameof(GetById), new { id = createdObject.Id }, createdObject);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] TwinObject obj)
        {
            return _twinService.Update(id, obj) ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(Guid id)
        {
            return _twinService(id) ? NoContent() : NotFound();
        }
}