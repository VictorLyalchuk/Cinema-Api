namespace Core.DTOs
{
    public class CreateMovieDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Year { get; set; }
        public TimeSpan Duration { get; set; }
        public IEnumerable<int> GenreID { get; set; }
    }
}
