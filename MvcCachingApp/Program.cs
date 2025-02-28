using Microsoft.Extensions.Caching.StackExchangeRedis;

namespace MvcCachingApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddMemoryCache(); // Add this line to add 'In-Memory Caching'

            builder.Services.AddResponseCaching(); // Add this line to 'Enable Response Caching'

            // Add Redis distributed cache
            builder.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "localhost:6379"; // Redis server connection string
                options.InstanceName = "SampleInstance"; // Optional instance name
            });


            var app = builder.Build();

            app.UseResponseCaching(); // Add this line to 'Enable Response Caching'

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
