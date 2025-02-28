using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MvcCachingApp.Models;
using System.Diagnostics;

namespace MvcCachingApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMemoryCache _memoryCache;

        public HomeController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            string cacheKey = "time";
            DateTime currentTime;
            if (!_memoryCache.TryGetValue(cacheKey, out currentTime))
            {
                currentTime = DateTime.Now;
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(30));
                _memoryCache.Set(cacheKey, currentTime, cacheEntryOptions);
            }

            ViewBag.CachedTime = currentTime;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [ResponseCache(Duration = 30)] // Cache the response for 30 seconds
        public IActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
    }
}
