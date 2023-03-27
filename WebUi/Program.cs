using CommunalCalculator;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using System.Web;

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
                app.UseExceptionHandler("/Calculation/Error");
            }

            // Change culture
            var appDefaultCulture = new CultureInfo("ru-RU")
            {
                NumberFormat =
            {
                NumberDecimalSeparator = ".",
            },
            };

            var supportedCultures = new[] { appDefaultCulture };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(appDefaultCulture),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });


            app.UseStaticFiles();

            app.UseRouting();
            

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Calculation}/{action=PutValues}");

            app.Run();
        }
    }
}