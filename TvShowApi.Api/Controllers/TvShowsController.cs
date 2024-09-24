using Microsoft.AspNetCore.Mvc;
using TvShowApi.Application.DTOs;
using TvShowApi.Application.Interfaces;

namespace TvShowApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TvShowsController : ControllerBase
    {
        private readonly ITvShowService _service;

        public TvShowsController(ITvShowService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAllTvShows());

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var show = _service.GetTvShowById(id);
            if (show == null) return NotFound();
            return Ok(show);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TvShowDto tvShowDto)
        {
            _service.CreateTvShow(tvShowDto);
            return CreatedAtAction(nameof(Get), new { id = tvShowDto.Name }, tvShowDto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] TvShowDto tvShowDto)
        {
            var show = _service.GetTvShowById(id);
            if (show == null) return NotFound();

            _service.UpdateTvShow(id, tvShowDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var show = _service.GetTvShowById(id);
            if (show == null) return NotFound();

            _service.DeleteTvShow(id);
            return NoContent();
        }
    }
}