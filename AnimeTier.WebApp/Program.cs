using AnimeTier.WebApp.Components;
using Radzen;

namespace AnimeTier.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7258/api/") });

            builder.Services.AddRazorComponents().AddInteractiveServerComponents();

            builder.Services.AddRadzenComponents();
            builder.Services.AddRadzenCookieThemeService(options =>
            {
                options.Name = "AnimeTierListTheme"; // The name of the cookie
                options.Duration = TimeSpan.FromDays(365); // The duration of the cookie
            });

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
