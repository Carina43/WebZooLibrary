using WebZooLibrary.Service;

namespace WebZooWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adding EventServices from WebZooLibawy
            builder.Services.AddSingleton<EventService>();
            builder.Services.AddSingleton<UserService>();
            // Add services to the container.
            builder.Services.AddRazorPages();
            // Add Services for sessions
            builder.Services.AddSession();
    
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.MapRazorPages();

            app.Run();
        }
    }
}
