using Microsoft.AspNetCore.Mvc;
using TvShowApi.Application.DTOs;
using TvShowApi.Application.Interfaces;

namespace TvShowApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TvShowsController : ControllerBase
    {
        private readonly ITvShowService _tvShowService;

        public TvShowsController(ITvShowService tvShowService)
        {
            _tvShowService = tvShowService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TvShowDto>> GetAll()
        {
            return Ok(_tvShowService.GetAllTvShows());
        }

        [HttpGet("{id}")]
        public ActionResult<TvShowDto> GetById(int id)
        {
            var tvShow = _tvShowService.GetTvShowById(id);
            if (tvShow == null) return NotFound();
            return Ok(tvShow);
        }

        [HttpPost]
        public ActionResult Create([FromBody] CreateTvShowDto createTvShowDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _tvShowService.CreateTvShow(createTvShowDto);
            return CreatedAtAction(nameof(GetById), new { id = createTvShowDto.Name }, createTvShowDto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] TvShowDto tvShowDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _tvShowService.UpdateTvShow(id, tvShowDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _tvShowService.DeleteTvShow(id);
            return NoContent();
        }
    }
}