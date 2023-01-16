using Microsoft.EntityFrameworkCore;
using MultiShop.DAL;
using MultiShop.Services;

namespace MultiShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL"));
            });
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<LayoutService>();
            var app = builder.Build();


            app.UseStaticFiles();

            app.UseRouting();

            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}