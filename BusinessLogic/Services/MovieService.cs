﻿using AutoMapper;
using Core.DTOs;
using Core.Interfaces;
using Core.Specification;
using Core.Entities;
using System.Net;
using Core.Helpers;

namespace Core.Services
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> _movieRepository;
        private readonly IRepository<MovieGenre> _moviegenreRepository;
        private readonly IMapper _mapper;
        public MovieService(IRepository<Movie> movieRepository, IMapper mapper, IRepository<MovieGenre> moviegenreRepository)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
            _moviegenreRepository = moviegenreRepository;
        }
        public async Task<List<MovieDTO>> GetAllAsync()
        {
            var movies = await _movieRepository.GetListBySpec(new MoviesSpecification.OrderByAllByID());
            return _mapper.Map<List<MovieDTO>>(movies);
        }
        public async Task<MovieDTO?> GetByIdAsync(int id)
        {
            var movie = await _movieRepository.GetItemBySpec(new MoviesSpecification.ByID(id));
            if (movie != null)
            {
                return _mapper.Map<MovieDTO>(movie);
            }
            else
            {
                throw new CustomHttpException(ErrorMessages.MovieNotFoundByID, HttpStatusCode.NotFound);
            }
        }
        public async Task CreateAsync(CreateMovieDTO movieDTO)
        {
            var movie = _mapper.Map<Movie>(movieDTO);
            await _movieRepository.InsertAsync(movie);
            await _movieRepository.SaveAsync();
            if (movieDTO.GenreID != null)
            {
                foreach (var genreid in movieDTO.GenreID)
                {
                    await _moviegenreRepository.InsertAsync(
                    new MovieGenre()
                    {
                        GenreID = genreid,
                        MovieID = movie.Id
                    });
                    await _moviegenreRepository.SaveAsync();
                }
            }
        }
        public async Task DeleteAsync(int id)
        {
            //if (_movieRepository.GetByIDAsync(id) == null)
            //    return;
            await _movieRepository.DeleteAsync(id);
            await _movieRepository.SaveAsync();
        }
        public async Task UpdateAsync(MovieDTO movieDTO)
        {
            var movie = await _movieRepository.GetByIDAsync(movieDTO.Id);
            if (movie != null)
            {
                await _moviegenreRepository.DeleteAsync(movie.Id);
                foreach (var genre in movieDTO.Genres)
                {
                    await _moviegenreRepository.InsertAsync(
                        new MovieGenre
                        {
                            GenreID = genre.Id,
                            MovieID = movie.Id
                        });
                    await _moviegenreRepository.SaveAsync();
                }
                await _movieRepository.UpdateAsync(movie);
                await _movieRepository.SaveAsync();
            }
        }
    }
}
