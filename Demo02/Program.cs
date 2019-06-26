using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Demo02
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //TODO: 1.1 Show webhost builder
            var host = WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();

            host.Run();
        }
    }
}
