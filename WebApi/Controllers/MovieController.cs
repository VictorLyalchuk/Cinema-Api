using Core.DTOs;
using Core.Interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Core.Services;

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
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateMovieDTO movie)
        {
            await _movie.CreateAsync(movie);
            return Ok();
        }
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, MovieDTO movie)
        {
            // Оновлення фільму з ідентифікатором id, використовуючи movie
            movie.Id = id; // Присвоюємо ідентифікатор, переданий у шляху, властивості Id у movie
            await _movie.UpdateAsync(movie);
            return Ok();
        }


        //[HttpPut("Edit")]
        //public async Task<IActionResult> Edit(MovieDTO movie)
        //{
        //    await _movie.UpdateAsync(movie);
        //    return Ok();
        //}
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("Delete")]
        public async Task <IActionResult> Delete(int id)
        {
            await _movie.DeleteAsync(id);
            return Ok();
        }
    }
}
