using PetShopWebApp.Repositories;
using PetShopWebApp.Repositories.Interfaces;

namespace PetShopWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddSingleton<IAnimal, AnimalRepository>();
            builder.Services.AddSingleton<IUsuario, UsuarioRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Animal}/{action=Index}/{id?}");

            app.Run();
        }
    }
}