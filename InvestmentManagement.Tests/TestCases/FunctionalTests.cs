
using InvestmentManagement.BusinessLayer.Interfaces;
using InvestmentManagement.BusinessLayer.Services;
using InvestmentManagement.BusinessLayer.Services.Repository;
using InvestmentManagement.BusinessLayer.ViewModels;
using InvestmentManagement.Entities;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace InvestmentManagement.Tests.TestCases
{
    public class FunctionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IInvestmentService _investmentService;
        public readonly Mock<IInvestmentRepository> investmentservice = new Mock<IInvestmentRepository>();

        private readonly Investment _investment;
        private readonly InvestmentViewModel _investmentViewModel;

        private static string type = "Functional";

        public FunctionalTests(ITestOutputHelper output)
        {
            _investmentService = new InvestmentService(investmentservice.Object);

            _output = output;

            _investment = new Investment
            {
                InvestorId=1,
                InvestmentId=11,
                InvestmentName="Test",
                InitialInvestmentAmount=10000,
                InvestmentStartDate=DateTime.Now,
                CurrentValue=1000,
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
        public async Task<bool> Testfor_Create_Investment()
        {
            //Arrange
            var res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                investmentservice.Setup(repos => repos.CreateInvestment(_investment)).ReturnsAsync(_investment);
                var result = await _investmentService.CreateInvestment(_investment);
                //Assertion
                if (result != null)
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
        public async Task<bool> Testfor_Update_Investment()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                investmentservice.Setup(repos => repos.UpdateInvestment(_investmentViewModel)).ReturnsAsync(_investment);
                var result = await _investmentService.UpdateInvestment(_investmentViewModel);
                if (result != null)
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
        public async Task<bool> Testfor_GetInvestmentById()
        {
            //Arrange
            var res = false;
            int id = 1;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                investmentservice.Setup(repos => repos.GetInvestmentById(id)).ReturnsAsync(_investment);
                var result = await _investmentService.GetInvestmentById(id);
                //Assertion
                if (result != null)
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
        public async Task<bool> Testfor_DeleteInvestmentById()
        {
            //Arrange
            var res = false;
            int id = 1;
            bool response = true;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                investmentservice.Setup(repos => repos.DeleteInvestmentById(id)).ReturnsAsync(response);
                var result = await _investmentService.DeleteInvestmentById(id);
                //Assertion
                if (result != null)
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