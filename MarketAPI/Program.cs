
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;

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
