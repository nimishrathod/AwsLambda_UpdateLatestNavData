using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Microsoft.Extensions.DependencyInjection;
using UpdateMutualFundNavData.Configuration;
using UpdateMutualFundNavData.DependencyResolver;
using UpdateMutualFundNavData.Services;
using MySql.Data.MySqlClient;
using RepoDb;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.LambdaJsonSerializer))]

namespace UpdateMutualFundNavData
{
    public class Function
    {
        private IFundNavDataProviderService FundNavDataProvider { get; }
        private IFundNavDataUpdaterService FundNavDataUpdater { get; }

        public Function(IServiceProvider serviceProvider)
        {
            FundNavDataProvider = serviceProvider.GetService<IFundNavDataProviderService>();
            FundNavDataUpdater = serviceProvider.GetService<IFundNavDataUpdaterService>();
        }

        public Function() : this(DependencyInjectionModule.Container.BuildServiceProvider())
        { }

        /// <summary>
        /// Get latest mutual fund nav data and update in database
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string FunctionHandler(ILambdaContext context)
        {
            var funds = FundNavDataProvider.GetLatestNavData();
            var recordsMerged = FundNavDataUpdater.UpdateLatestNavData(funds);
            return "Success. Total merged records: " + recordsMerged;
        }
    }
}
