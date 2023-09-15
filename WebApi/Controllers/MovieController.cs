using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IRepository<Movie> _movieRepository;
        public MovieController(IRepository<Movie> repository)
        {
            _movieRepository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _movieRepository.GetAsync(includeProperties: new[] { "Genres"}));
            //return Ok(await _movieRepository.GetAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _movieRepository.GetByIDAsync(id));
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(Movie movie)
        {
            await _movieRepository.InsertAsync(movie);
            await _movieRepository.SaveAsync();
            return Ok();
        }
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(Movie movie)
        {
            await _movieRepository.UpdateAsync(movie);
            await _movieRepository.SaveAsync();
            return Ok();
        }
        [HttpDelete("Delete")]
        public async Task <IActionResult> Delete(int id)
        {
            await _movieRepository.DeleteAsync(id);
            await _movieRepository.SaveAsync();
            return Ok();
        }
    }
}
