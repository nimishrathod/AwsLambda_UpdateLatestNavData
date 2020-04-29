using System;

namespace UpdateMutualFundNavData.Models
{
    public class MutualFunds
    {
        public string SchemeCode { get; set; }
        public string IsinGrowthDivPayOut { get; set; }
        public string IsinDivReInvest { get; set; }
        public string SchemeName { get; set; }
        public decimal CurrentNav { get; set; }
        public DateTime CurrentNavDate { get; set; }

    }
}