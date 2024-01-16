using Castle.Core.Resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InvestmentManagement.Entities
{
    public class Investment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long InvestmentId { get; set; }
        public string InvestmentName { get; set; }
        public decimal InitialInvestmentAmount { get; set; }
        public DateTime InvestmentStartDate { get; set; }
        public decimal CurrentValue { get; set; }
        public int InvestorId { get; set; }
    }
}
