using DataAccessLayer.Data;
using DataAccessLayer.Repositories;
using Services.Profiles;
using Microsoft.EntityFrameworkCore;
using Services;
using Microsoft.OpenApi.Models;

namespace MarketAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers().AddNewtonsoftJson();

            // Swagger (Swashbuckle)
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MarketAPI",
                    Version = "v1",
                    Description = "Ett litet REST API för annonser, bud och användare. Av Jon Johansson 2025."
                });
            });

            // DbContext
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // DataInitializer
            builder.Services.AddTransient<DataInitializer>();

            // Services
            builder.Services.AddScoped<IAdService, AdService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IBidService, BidService>();

            // Repositories
            builder.Services.AddScoped<IAdRepository, AdRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IBidRepository, BidRepository>();

            // AutoMapper
            builder.Services.AddAutoMapper(typeof(AdProfile), typeof(UserProfile), typeof(BidProfile));

            var app = builder.Build();

            // Migrate database and seed data
            using (var scope = app.Services.CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<DataInitializer>().MigrateData();
            }

            // Swagger UI
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MarketAPI");
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            // Redirect root to Swagger UI
            app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();

            app.Run();
        }
    }
}
