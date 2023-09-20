using Ardalis.Specification;
using Core.Entities;

namespace Core.Specification
{
    public static class MoviesSpecification
    {
        public class OrderByAll : Specification<Movie>
        {
            public OrderByAll()
            {
                Query
                    .OrderBy(c => c.Title)
                    .Include(c => c.Genres)
                    .ThenInclude(c => c._Genre);
            }
        }
        public class OrderByAllByID : Specification<Movie>
        {
            public OrderByAllByID()
            {
                Query
                    .Include(c => c.Genres)
                    .ThenInclude(c => c._Genre)
                    .OrderBy(c => c.Id);
            }
        }
        public class ByID : Specification<Movie>
        {
            public ByID(int ID)
            {
                Query
                    .Include(c => c.Genres)
                    .ThenInclude(c => c._Genre)
                    .Where(c => c.Id == ID);
            }
        }
    }
}
