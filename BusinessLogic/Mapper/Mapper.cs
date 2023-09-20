using BusinessLogic.DTOs;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Mapper
{
    public class Mapper : AutoMapper.Profile
    {
        public Mapper()
        {
            CreateMap<Genre, GenreDTO>().ReverseMap();
            CreateMap<Movie, MovieDTO>().ForMember(movieDTO => movieDTO.Genres, opt => opt.MapFrom(movie => movie.Genres.Select(a => a._Genre)));
            CreateMap<MovieDTO, Movie>();
            
            CreateMap<CreateMovieDTO, Movie>();
        }
    }
}
