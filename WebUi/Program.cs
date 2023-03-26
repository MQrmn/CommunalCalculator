using CommunalCalculator;

namespace WebUi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<Calculator>();
            builder.Services.AddScoped<ICurrentResultsRepository, CurrentResultsRepository>();
            builder.Services.AddScoped<ICalculationService, CalculationService>();

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
                pattern: "{controller=Calculate}/{action=GetValues}/{id?}");

            app.Run();
        }
    }
}