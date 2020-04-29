using Microsoft.Extensions.Configuration;

namespace UpdateMutualFundNavData.Configuration
{
    public interface ILambdaConfiguration
    {
        string ConnectionString { get; }
        string MutualFundServiceUrl { get; }
    }
}