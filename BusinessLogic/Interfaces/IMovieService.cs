using BusinessLogic.DTOs;


namespace BusinessLogic.Interfaces
{
    public interface IMovieService
    {
        Task <List<MovieDTO>> GetAllAsync();
        Task <MovieDTO?> GetByIdAsync(int id);
        Task CreateAsync(CreateMovieDTO movie);
        Task UpdateAsync(MovieDTO movie);
        Task DeleteAsync(int id);
    }
}
