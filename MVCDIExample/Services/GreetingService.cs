namespace MVCDIExample.Services
{
    public class GreetingService : IGreetingService
    {
        public string GetGreeting(string name)
        {
            return $"Hello, {name}! The time is {DateTime.Now:t}";
        }
    }
}
