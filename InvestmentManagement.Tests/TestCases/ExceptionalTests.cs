

using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using InvestmentManagement.BusinessLayer.ViewModels;
using InvestmentManagement.Entities;
using InvestmentManagement.BusinessLayer.Interfaces;
using InvestmentManagement.BusinessLayer.Services.Repository;
using InvestmentManagement.BusinessLayer.Services;
using InvestmentManagement.Tests.TestCases;

namespace InvestmentManagement.Tests.TestCases
{
    public class ExceptionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IInvestmentService _investmentService;
        public readonly Mock<IInvestmentRepository> investmentservice = new Mock<IInvestmentRepository>();

        private readonly Investment _investment;
        private readonly InvestmentViewModel _investmentViewModel;

        private static string type = "Exception";

        public ExceptionalTests(ITestOutputHelper output)
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
        public async Task<bool> Testfor_Validate_IfInvalidInvestorIdIsPassed()
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
                if (result != null || result.InvestorId !=0)
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
        public async Task<bool> Testfor_Validate_IfInvalidInvestmentIdIsPassed()
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
                if (result != null || result.InvestmentId != null)
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