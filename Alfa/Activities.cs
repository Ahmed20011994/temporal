using Temporalio.Activities;

namespace Alfa
{
    public class Activities
    {
        // Activities can be async and/or static too! We just demonstrate instance
        // methods since many will use them that way.
        [Activity]
        public string SayHelloWorld(string name) => $"Hello World, {name}! Greetings from Alfa";

        // Activities can be async and/or static too! We just demonstrate instance
        // methods since many will use them that way.
        [Activity]
        public string SayHelloUniverse(string name) => $"Hello Universe, {name}! Greetings from Alfa";
    }
}
