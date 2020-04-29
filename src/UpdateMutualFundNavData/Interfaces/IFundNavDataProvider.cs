using System.Collections.Generic;
using UpdateMutualFundNavData.Models;

namespace UpdateMutualFundNavData.Services
{
    public interface IFundNavDataProviderService
    {
        List<MutualFunds> GetLatestNavData();
    }
}