using InvestmentManagement.BusinessLayer.ViewModels;
using InvestmentManagement.DataLayer;
using InvestmentManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentManagement.BusinessLayer.Services.Repository
{
    public class InvestmentRepository : IInvestmentRepository
    {
        private readonly InvestmentDbContext _dbContext;
        public InvestmentRepository(InvestmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Investment> CreateInvestment(Investment investment)
        {
            try
            {
                var result = await _dbContext.Investments.AddAsync(investment);
                await _dbContext.SaveChangesAsync();
                return investment;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<bool> DeleteInvestmentById(long id)
        {
            try
            {
                _dbContext.Remove(_dbContext.Investments.Single(a => a.InvestmentId == id));
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<Investment> GetAllInvestments()
        {
            try
            {
                var result = _dbContext.Investments.
                OrderByDescending(x => x.InvestmentId).Take(10).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Investment> GetInvestmentById(long id)
        {
            try
            {
                return await _dbContext.Investments.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public async Task<Investment> UpdateInvestment(InvestmentViewModel model)
        {
            var Investment = await _dbContext.Investments.FindAsync(model.InvestmentId);
            try
            {
                Investment.InvestmentStartDate = model.InvestmentStartDate;
                Investment.InvestmentName = model.InvestmentName;
                Investment.InitialInvestmentAmount = model.InitialInvestmentAmount;
                Investment.CurrentValue = model.CurrentValue;
                Investment.InvestmentId = model.InvestmentId;
                Investment.InvestmentId = model.InvestmentId;

                _dbContext.Investments.Update(Investment);
                await _dbContext.SaveChangesAsync();
                return Investment;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}