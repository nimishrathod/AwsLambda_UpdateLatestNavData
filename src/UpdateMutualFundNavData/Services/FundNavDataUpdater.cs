using System;
using System.Collections.Generic;
using System.Net;
using UpdateMutualFundNavData.Configuration;
using UpdateMutualFundNavData.Models;
using MySql.Data.MySqlClient;
using RepoDb;

namespace UpdateMutualFundNavData.Services
{
    public class FundNavDataUpdaterService : IFundNavDataUpdaterService
    {
        private ILambdaConfiguration LambdaConfiguration { get; }
        public FundNavDataUpdaterService(ILambdaConfiguration lambdaConfiguration)
        {
            LambdaConfiguration = lambdaConfiguration;
        }

        public int UpdateLatestNavData(List<MutualFunds> funds)
        {
            RepoDb.MySqlBootstrap.Initialize();
            int recordsMerged = 0;
            using (var conn = new MySqlConnection(LambdaConfiguration.ConnectionString))
            {
                conn.ExecuteNonQuery("Update MutualFunds set LastNav = CurrentNav, " +
                    "LastNavDate = CurrentNavDate;");
                recordsMerged = conn.MergeAll(funds, qualifiers: Field.From("SchemeCode"));
            }

            return recordsMerged;
        }

    }
}