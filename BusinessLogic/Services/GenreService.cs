using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using DataAccess.Entities;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class GenreService : IGenreService
    {
        private readonly IRepository<Genre> _genreRepository;
        private readonly IMapper _mapper;
        public GenreService(IRepository<Genre> genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }
        public async Task CreateAsync(GenreDTO genreDTO)
        {
            var genre = _mapper.Map<Genre>(genreDTO);
            await _genreRepository.InsertAsync(genre);
            await _genreRepository.SaveAsync();
        }
        public async Task DeleteAsync(int id)
        {
            if (_genreRepository.GetByIDAsync(id) != null)
            {
                await _genreRepository.DeleteAsync(id);
                await _genreRepository.SaveAsync();
            }
        }
        public async Task<List<GenreDTO>> GetAllAsync()
        {
            var genres = _genreRepository.GetAsync(includeProperties: new[] { "Movies" });
            return _mapper.Map<List<GenreDTO>>(genres);
        }
        public async Task<GenreDTO?> GetByIdAsync(int id)
        {
            var genre = await _genreRepository.GetByIDAsync(id);
            if (genre != null)
            {
                return _mapper.Map<GenreDTO>(genre);
            }
            else
            {
                return null;
            }
        }
        public async Task UpdateAsync(GenreDTO genreDTO)
        {
            var genre = await _genreRepository.GetByIDAsync(genreDTO.Id);
            if (genre != null)
            {
                await _genreRepository.UpdateAsync(genre);
                await _genreRepository.SaveAsync();
            }
        }
    }
}
