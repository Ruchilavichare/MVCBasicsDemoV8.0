using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;

namespace MvcCachingApp.Controllers
{
    public class RedisCacheController : Controller
    {
        private readonly IDistributedCache _distributedCache;

        public RedisCacheController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task<IActionResult> Index()
        {
            string cacheKey = "distributed_time";
            var cachedTime = await _distributedCache.GetStringAsync(cacheKey);
            if (cachedTime == null)
            {
                cachedTime = DateTime.Now.ToString();
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(30));
                await _distributedCache.SetStringAsync(cacheKey, cachedTime, options);
            }

            ViewBag.CachedTime = cachedTime;
            return View();
        }
    }
}
