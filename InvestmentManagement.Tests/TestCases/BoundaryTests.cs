
using InvestmentManagement.BusinessLayer.Interfaces;
using InvestmentManagement.BusinessLayer.Services.Repository;
using InvestmentManagement.BusinessLayer.Services;
using InvestmentManagement.BusinessLayer.ViewModels;
using InvestmentManagement.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace InvestmentManagement.Tests.TestCases
{
    public class BoundaryTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IInvestmentService _investmentService;
        public readonly Mock<IInvestmentRepository> investmentservice = new Mock<IInvestmentRepository>();

        private readonly Investment _investment;
        private readonly InvestmentViewModel _investmentViewModel;

        private static string type = "Boundary";

        public BoundaryTests(ITestOutputHelper output)
        {
            _investmentService = new InvestmentService(investmentservice.Object);

            _output = output;

            _investment = new Investment
            {
                InvestorId = 1,
                InvestmentId = 11,
                InvestmentName = "Test",
                InitialInvestmentAmount = 10000,
                InvestmentStartDate = DateTime.Now,
                CurrentValue = 1000,
            };

            _investmentViewModel = new InvestmentViewModel
            {
                InvestorId = 1,
                InvestmentId = 11,
                InvestmentName = "Test",
                InitialInvestmentAmount = 10000,
                InvestmentStartDate = DateTime.Now,
                CurrentValue = 1000,
            };
        }

        [Fact]
        public async Task<bool> Testfor_InvestmentName_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                investmentservice.Setup(repo => repo.CreateInvestment(_investment)).ReturnsAsync(_investment);
                var result = await  _investmentService.CreateInvestment(_investment);
                var actualLength = _investment.InvestmentName.ToString().Length;
                if (result.InvestmentName.ToString().Length == actualLength)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }
       
        [Fact]
        public async Task<bool> Testfor_InitialInvestmentAmount_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                investmentservice.Setup(repo => repo.CreateInvestment(_investment)).ReturnsAsync(_investment);
                var result = await  _investmentService.CreateInvestment(_investment);
                var actualLength = _investment.InitialInvestmentAmount.ToString().Length;
                if (result.InitialInvestmentAmount.ToString().Length == actualLength)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_InvestorId_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                investmentservice.Setup(repo => repo.CreateInvestment(_investment)).ReturnsAsync(_investment);
                var result = await _investmentService.CreateInvestment(_investment);
                var actualLength = _investment.InvestorId.ToString().Length;
                if (result.InvestorId.ToString().Length == actualLength)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

        [Fact]
        public async Task<bool> Testfor_InvestmentId_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                investmentservice.Setup(repo => repo.CreateInvestment(_investment)).ReturnsAsync(_investment);
                var result = await  _investmentService.CreateInvestment(_investment);
                var actualLength = _investment.InvestmentId.ToString().Length;
                if (result.InvestmentId.ToString().Length == actualLength)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }

    }
}