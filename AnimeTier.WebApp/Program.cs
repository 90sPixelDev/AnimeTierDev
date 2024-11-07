using AnimeTier.WebApp.Components;
using AnimeTier.WebApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.Extensions.Configuration;
using Radzen;
using SharedLibrary.Context;

namespace AnimeTier.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRadzenComponents();
            builder.Services.AddRazorComponents().AddInteractiveServerComponents();
            builder.Services.AddRadzenCookieThemeService(options =>
            {
                options.Name = "AnimeTierListTheme"; // The name of the cookie
                options.Duration = TimeSpan.FromDays(365); // The duration of the cookie
            });
            builder.Services.AddDbContextFactory<AnimeTierListContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("AnimeTierDBCnnStr")));
            builder.Services.AddScoped<AnimeService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
