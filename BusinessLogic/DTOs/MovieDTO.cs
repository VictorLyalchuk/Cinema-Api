namespace Core.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = $"https://www.booooooom.com/wp-content/uploads/2015/04/emptyfilmposters-08.jpg";
        public int Year { get; set; }
        public TimeSpan Duration { get; set; }
        public IEnumerable<GenreDTO> Genres { get; set; }
    }
}
