using Microsoft.AspNetCore.Mvc;
using ProjectReviewWebAPI.Application.Services.Abstractions;
using ProjectReviewWebAPI.Domain.Dtos;
using ProjectReviewWebAPI.Shared    .Dtos.RequestDtos;
using ProjectReviewWebAPI.Shared.Dtos.ResponseDto;
using ProjectReviewWebAPI.Shared.RequestParameter.Common;
using ProjectReviewWebAPI.Shared.RequestParameter.ModelParameters;
using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectReview.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        /// <summary>
        /// Returns all transactions
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <returns></returns>

        // GET: api/<TransactionController>
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StandardResponse<PagedList<TransactionResponseDto>>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        [HttpGet("allTransactions")]
        public async Task<IActionResult> GetAllTransaction([FromQuery] TransactionRequestInputParameter parameter)
        {
            var result = await _transactionService.GetAllTransactionsAsync(parameter);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.MetaData));

            return StatusCode(result.StatusCode, result);
        }

        /// <summary>
        /// Returns a transaction by passing invoice-code as method parameter
        /// </summary>
        /// <param name="invoiceCode"></param>
        /// <returns></returns>

        // GET api/<TransactionController>/5
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StandardResponse<TransactionResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        [HttpGet("invoiceCode/{invoiceCode}")]
        public async Task<IActionResult> GetByInvoiceCode( string invoiceCode)
        {
            var result = await _transactionService.GetTransactionByInvoiceCode(invoiceCode);

            return Ok(result);
        }

        /// <summary>
        /// Returns a transaction by passing projectId as method parameter
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>

        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StandardResponse<TransactionResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        [HttpGet("projectId/{projectId}")]
        public async Task<IActionResult> GetByProjectId(string projectId)
        {
            var result = await _transactionService.GetTransactionByProjectId(projectId);

            return Ok(result);
        }

        /// <summary>
        /// Creates a transaction by passing required contents via transactionRequestDto
        /// </summary>
        /// <param name="transactionRequestDto"></param>
        /// <returns></returns>

        // POST api/<TransactionController>
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(StandardResponse<TransactionResponseDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status409Conflict)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable)]
        [HttpPost("/addTransaction")]
        public async Task<IActionResult> AddTransaction([FromBody] TransactionRequestDto transactionRequestDto)
        {
            var result = await _transactionService.AddTransaction(transactionRequestDto);
            return Ok(result);
        }

    }
}
