using System.IO;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace UpdateMutualFundNavData.Configuration
{
    public class LambdaConfiguration : ILambdaConfiguration
    {
        private IConfiguration Configuration;
        public LambdaConfiguration()
        {
            Configuration = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .Build();
        }

        public string ConnectionString => Configuration["ConnectionString"];

        public string MutualFundServiceUrl => Configuration["MutualFundServiceUrl"];

    }
}