using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentManagement.BusinessLayer.ViewModels
{
    public class InvestmentViewModel
    {
        public long InvestmentId { get; set; }
        public string InvestmentName { get; set; }
        public decimal InitialInvestmentAmount { get; set; }
        public DateTime InvestmentStartDate { get; set; }
        public decimal CurrentValue { get; set; }
        public int InvestorId { get; set; }
    }
}
