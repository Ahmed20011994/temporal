using Temporalio.Activities;

namespace Bravo
{
    public class Activities
    {
        // Activities can be async and/or static too! We just demonstrate instance
        // methods since many will use them that way.
        [Activity]
        public string SayHello(string name) => $"Hello, {name}! Greetings from Bravo";
    }
}
