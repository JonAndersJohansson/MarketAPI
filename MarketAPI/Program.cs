using DataAccessLayer.Data;
using DataAccessLayer.Repositories;
using Services.Profiles;
using Microsoft.EntityFrameworkCore;
using Services;

namespace MarketAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            // DbContext
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // DataInitializer, Dependency Injection
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


            // MigrateData()
            using (var scope = app.Services.CreateScope())
            {
                scope.ServiceProvider.GetService<DataInitializer>().MigrateData();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwaggerUI(options =>
                    options.SwaggerEndpoint("/openapi/v1.json", "superHero api"));
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.MapGet("/", () => Results.Redirect("/swagger"))
                .ExcludeFromDescription();

            app.Run();
        }
    }
}
