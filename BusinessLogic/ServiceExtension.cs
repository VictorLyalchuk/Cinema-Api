using Core.Interfaces;
using Core.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public static class ServiceExtension
    {
        public static void AddCustomService(this IServiceCollection service)
        {
            service.AddScoped<IMovieService, MovieService>();

            service.AddScoped<IGenreService, GenreService>();

            service.AddScoped<IAccountService, AccountService>();

        }
        public static void AddValidator(this IServiceCollection service)
        {
            service.AddFluentValidationAutoValidation();

            service.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

        }
        public static void AddAutoMapper(this IServiceCollection service)
        {
            service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
