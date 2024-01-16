using InvestmentManagement.BusinessLayer.Interfaces;
using InvestmentManagement.BusinessLayer.ViewModels;
using InvestmentManagement.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvestmentManagement.Controllers
{
    [ApiController]
    public class InvestmentController : ControllerBase
    {
        private readonly IInvestmentService _investmentService;
        public InvestmentController(IInvestmentService investmentService)
        {
            _investmentService = investmentService;
        }

        [HttpPost]
        [Route("create-investment")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateInvestment([FromBody] Investment model)
        {
            var InvestmentExists = await _investmentService.GetInvestmentById(model.InvestmentId);
            if (InvestmentExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Investment already exists!" });
            var result = await _investmentService.CreateInvestment(model);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Investment creation failed! Please check details and try again." });

            return Ok(new Response { Status = "Success", Message = "Investment created successfully!" });

        }


        [HttpPut]
        [Route("update-investment")]
        public async Task<IActionResult> UpdateInvestment([FromBody] InvestmentViewModel model)
        {
            var Investment = await _investmentService.UpdateInvestment(model);
            if (Investment == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Investment With Id = {model.InvestmentId} cannot be found" });
            }
            else
            {
                var result = await _investmentService.UpdateInvestment(model);
                return Ok(new Response { Status = "Success", Message = "Investment updated successfully!" });
            }
        }

        [HttpDelete]
        [Route("delete-Investment")]
        public async Task<IActionResult> DeleteInvestment(long id)
        {
            var Investment = await _investmentService.GetInvestmentById(id);
            if (Investment == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Investment With Id = {id} cannot be found" });
            }
            else
            {
                var result = await _investmentService.DeleteInvestmentById(id);
                return Ok(new Response { Status = "Success", Message = "Investment deleted successfully!" });
            }
        }


        [HttpGet]
        [Route("get-Investment-by-id")]
        public async Task<IActionResult> GetInvestmentById(long id)
        {
            var Investment = await _investmentService.GetInvestmentById(id);
            if (Investment == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Investment With Id = {id} cannot be found" });
            }
            else
            {
                return Ok(Investment);
            }
        }

        [HttpGet]
        [Route("get-all-investments")]
        public async Task<IEnumerable<Investment>> GetAllInvestments()
        {
            return _investmentService.GetAllInvestments();
        }
    }
}