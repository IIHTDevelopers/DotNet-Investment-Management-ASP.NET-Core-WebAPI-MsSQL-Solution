using InvestmentManagement.BusinessLayer.Interfaces;
using InvestmentManagement.BusinessLayer.Services.Repository;
using InvestmentManagement.BusinessLayer.ViewModels;
using InvestmentManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentManagement.BusinessLayer.Services
{
    public class InvestmentService : IInvestmentService
    {
        private readonly IInvestmentRepository _investmentRepository;

        public InvestmentService(IInvestmentRepository investmentRepository)
        {
            _investmentRepository = investmentRepository;
        }

        public async Task<Investment> CreateInvestment(Investment investment)
        {
            return await _investmentRepository.CreateInvestment(investment);
        }

        public async Task<bool> DeleteInvestmentById(long id)
        {
            return await _investmentRepository.DeleteInvestmentById(id);
        }

        public List<Investment> GetAllInvestments()
        {
            return _investmentRepository.GetAllInvestments();
        }

        public async Task<Investment> GetInvestmentById(long id)
        {
            return await _investmentRepository.GetInvestmentById(id);
        }

        public async Task<Investment> UpdateInvestment(InvestmentViewModel model)
        {
            return await _investmentRepository.UpdateInvestment(model);
        }
    }
}