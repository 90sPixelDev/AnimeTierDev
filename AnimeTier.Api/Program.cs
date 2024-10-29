using AnimeTier.Api.Interfaces;
using AnimeTier.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Context;

namespace AnimeTier.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var AnimeCorsPolicy = "_animeCorsPolicy";

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: AnimeCorsPolicy,
                    builder =>
                    {
                        builder.WithOrigins("*")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });

            // Add services to the container.
            builder.Services.AddScoped<IAnimeRepository, AnimeRepo>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContextFactory<AnimeTierListContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("AnimeTierLH"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(AnimeCorsPolicy);
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
