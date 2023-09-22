﻿using Microsoft.AspNetCore.Mvc;
using ProjectReviewWebAPI.Application.Services.Abstractions;
using ProjectReviewWebAPI.Domain.Dtos.RequestDtos;
using ProjectReviewWebAPI.Shared.RequestParameter.ModelParameters;
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
        [HttpGet("allTransactions")]
        public async Task<IActionResult> GetAllTransaction([FromQuery] int pageNumber)
        {
            var result = await _transactionService.GetAllTransactionsAsync(pageNumber);
            //Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.Item2));

            return Ok(result);
        }

        /// <summary>
        /// Returns a transaction by passing invoice-code as method parameter
        /// </summary>
        /// <param name="invoiceCode"></param>
        /// <returns></returns>

        // GET api/<TransactionController>/5
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
        [HttpPost("/addTransaction")]
        public async Task<IActionResult> AddTransaction([FromBody] TransactionRequestDto transactionRequestDto)
        {
            var result = await _transactionService.AddTransaction(transactionRequestDto);
            return Ok(result);
        }

    }
}
