using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class MovieGenre
    {
        //public int Id { get; set; }
        [Key]
        public int MovieID { get; set; }
        public Movie? _Movie { get; set; }
        [Key]
        public int GenreID { get; set; }
        public Genre? _Genre { get; set; }
    }
}
