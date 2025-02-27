namespace MVCDIExample.Services
{
    public class SimpleGreetingService : IGreetingService
    {
        public string GetGreeting(string name)
        {
            return $"Hi {name}! This is a simple greeting.";
        }
    }
}
