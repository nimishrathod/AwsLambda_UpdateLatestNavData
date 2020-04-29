using System.Collections.Generic;
using UpdateMutualFundNavData.Models;

namespace UpdateMutualFundNavData.Services
{
    public interface IFundNavDataUpdaterService
    {
        int UpdateLatestNavData(List<MutualFunds> funds);
    }
}