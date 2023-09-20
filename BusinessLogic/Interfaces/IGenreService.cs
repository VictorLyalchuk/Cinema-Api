using Core.DTOs;


namespace Core.Interfaces
{
    public interface IGenreService
    {
        Task<List<GenreDTO>> GetAllAsync();
        Task<GenreDTO?> GetByIdAsync(int id);
        Task CreateAsync(GenreDTO genreDTO);
        Task UpdateAsync(GenreDTO genreDTO);
        Task DeleteAsync(int id);
    }
}
