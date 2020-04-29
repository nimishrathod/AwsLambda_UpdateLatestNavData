using System;
using System.Collections.Generic;
using System.Net;
using UpdateMutualFundNavData.Configuration;
using UpdateMutualFundNavData.Models;

namespace UpdateMutualFundNavData.Services
{
    public class FundNavDataProviderService : IFundNavDataProviderService
    {
        private ILambdaConfiguration LambdaConfiguration { get; }
        public FundNavDataProviderService(ILambdaConfiguration lambdaConfiguration)
        {
            LambdaConfiguration = lambdaConfiguration;
        }
        public List<MutualFunds> GetLatestNavData()
        {
            var client = new WebClient();
            var mutualFundRawDataString = client.DownloadString(LambdaConfiguration.MutualFundServiceUrl);

            var mutualFundRawData = mutualFundRawDataString.Split(Environment.NewLine);

            var fundList = new List<MutualFunds>();

            for (int i = 1; i < mutualFundRawData.Length; i++)
            {
                var mutualFundData = mutualFundRawData[i].Split(";");
                if (mutualFundData.Length != 6) continue;
                decimal currentNav = 0;
                decimal.TryParse(mutualFundData[4], out currentNav);

                DateTime currentNavDate = DateTime.Today;
                DateTime.TryParse(mutualFundData[5], out currentNavDate);
                fundList.Add(new MutualFunds()
                {
                    SchemeCode = mutualFundData[0],
                    IsinGrowthDivPayOut = mutualFundData[1],
                    IsinDivReInvest = mutualFundData[2],
                    SchemeName = mutualFundData[3],
                    CurrentNav = currentNav,
                    CurrentNavDate = currentNavDate
                });

            }

            return fundList;
        }

    }
}