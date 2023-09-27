using Core.DTOs;
using Core.DTOs.User;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapper
{
    public class Mapper : AutoMapper.Profile
    {
        public Mapper()
        {
            CreateMap<Genre, GenreDTO>().ReverseMap();
            CreateMap<Movie, MovieDTO>().ForMember(movieDTO => movieDTO.Genres, opt => opt.MapFrom(movie => movie.Genres.Select(a => a._Genre)));
            CreateMap<MovieDTO, Movie>();
            
            CreateMap<CreateMovieDTO, Movie>();
            CreateMap<RegistrationDTO, IdentityUser >();
            CreateMap<LoginDTO, IdentityUser>();
        }
    }
}
