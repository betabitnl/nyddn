using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Demo01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();

            host.Run();
        }
    }
}