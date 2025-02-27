using MVCDIExample.Services;

namespace MVCDIExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Register your custom services
            builder.Services.AddScoped<IGreetingService, GreetingService>();

            //Configuration-Based Service Selection
            var useSimpleGreeting = builder.Configuration.GetValue<bool>("UseSimpleGreeting");

            builder.Services.AddScoped<IGreetingService>(provider =>
                useSimpleGreeting
                    ? new SimpleGreetingService()
                    : new GreetingService()
            );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
