using InvestmentManagement.BusinessLayer.ViewModels;
using InvestmentManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentManagement.BusinessLayer.Services.Repository
{
    public interface IInvestmentRepository
    {
        List<Investment> GetAllInvestments();
        Task<Investment> CreateInvestment(Investment investment);
        Task<Investment> GetInvestmentById(long id);
        Task<bool> DeleteInvestmentById(long id);
        Task<Investment> UpdateInvestment(InvestmentViewModel model);
    }
}
