using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
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
    }
}
