using Core.DTOs;
using Core.Interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movie;
        public MovieController(IMovieService movie)
        {
            _movie = movie;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _movie.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _movie.GetByIdAsync(id));
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateMovieDTO movie)
        {
            await _movie.CreateAsync(movie);
            return Ok();
        }
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(MovieDTO movie)
        {
            await _movie.UpdateAsync(movie);
            return Ok();
        }
        [HttpDelete("Delete")]
        public async Task <IActionResult> Delete(int id)
        {
            await _movie.DeleteAsync(id);
            return Ok();
        }
    }
}
