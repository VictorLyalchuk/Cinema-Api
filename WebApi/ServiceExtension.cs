using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;

namespace WebApi
{
    public static class ServiceExtension
    {
        public static void AddSwaggerGenWithCustomSchema(this IServiceCollection service)
        {
            service.AddSwaggerGen(options =>
            {
                options.MapType<TimeSpan>(() => new OpenApiSchema
                {
                    Type = "string",
                    Example = new OpenApiString("00:00:00")
                });
            });
        }
        public static void AddControllersWithCustomSchema(this IServiceCollection service)
        {
            service.AddControllers()
                    .AddJsonOptions(a => a.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        }
        public static void AddAuthenticationWithOptions(this IServiceCollection service, IConfiguration configuration)
        {

            service.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!)),
                };
            });
        }
    }
}
