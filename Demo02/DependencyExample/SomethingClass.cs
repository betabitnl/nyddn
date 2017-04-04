using Microsoft.Extensions.Logging;

namespace Demo02.DependencyExample
{
    public class SomethingClass : ISomethingClass
    {
        public SomethingClass(ILoggerFactory loggerFactory)
        {
            loggerFactory.CreateLogger<SomethingClass>().LogInformation("=======> SomethingClass is created <=============");
        }
    }
}
