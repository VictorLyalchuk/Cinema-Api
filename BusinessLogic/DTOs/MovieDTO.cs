namespace Core.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Year { get; set; }
        public TimeSpan Duration { get; set; }
        public IEnumerable<GenreDTO> Genres { get; set; }
    }
}
