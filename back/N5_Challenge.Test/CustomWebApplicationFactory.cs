using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace N5_Challenge.Test
{
    public class CustomWebApplicationFactory<TProgram>
    : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            Environment.SetEnvironmentVariable("DB_CNN_STRING", "Server=localhost,4307;Database=N5Challenge;User=sa;Password=Pass@word;TrustServerCertificate=true;");
            Environment.SetEnvironmentVariable("ELASTICSEARCH_SERVER", "elasticsearch:9200");
            Environment.SetEnvironmentVariable("ELASTICSEARCH_INDEX", "default");
        }
    }
}