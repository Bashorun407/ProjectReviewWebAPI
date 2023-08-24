using AutoMapper;
using Microsoft.Extensions.Logging;
using ProjectReviewWebAPI.Application.Services.Abstractions;
using ProjectReviewWebAPI.Domain.Dtos;
using ProjectReviewWebAPI.Domain.Dtos.RequestDtos;
using ProjectReviewWebAPI.Domain.Dtos.ResponseDto;
using ProjectReviewWebAPI.Domain.Entities;
using ProjectReviewWebAPI.Infrastructure.UoW.Abstraction;
using ProjectReviewWebAPI.Shared.RequestParameter.Common;
using ProjectReviewWebAPI.Shared.RequestParameter.ModelParameters;
using ProjectReviewWebAPI.Utility.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Application.Services.Implementations
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<TransactionService> _logger;

        public TransactionService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<TransactionService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<StandardResponse<TransactionResponseDto>> AddTransaction(TransactionRequestDto transactionResquestDto)
        {
            //Checking if entered email is valid
            if(!Utilities.IsValidEmail(transactionResquestDto.Email))
            {
                return StandardResponse<TransactionResponseDto>.Failed("Email is invalid", 99);
            }

            _logger.LogInformation($"Creating transaction");
            var transaction = _mapper.Map<Transaction>(transactionResquestDto);

            //Setting the internally generated invoice code of the transaction
            transaction.InvoiceCode = Utilities.GenerateUniqueId();
            await _unitOfWork.TransactionRepository.CreateAsync(transaction);
            _logger.LogInformation("Saving new transaction to database");
            await _unitOfWork.SaveAsync();

            var transactionDto = _mapper.Map<TransactionResponseDto>(transaction);

            return StandardResponse<TransactionResponseDto>.Success("New transaction added", transactionDto, 201); ;
        }

        public async Task<StandardResponse<(IEnumerable<TransactionResponseDto> transactions, MetaData pagingData)>> GetAllTransactionsAsync(TransactionRequestInputParameter parameter)
        {
            var result = await _unitOfWork.TransactionRepository.GetAllTransaction(parameter);

            var transactionsDto = _mapper.Map<IEnumerable<TransactionResponseDto>>(result);

            return StandardResponse<(IEnumerable<TransactionResponseDto>, MetaData)>.Success("All transactions", (transactionsDto, result.MetaData), 200);
        }

        public async Task<StandardResponse<TransactionResponseDto>> GetTransactionByInvoiceCode(string invoiceCode)
        {
            var transaction = await _unitOfWork.TransactionRepository.GetTransactionByInvoiceCode(invoiceCode);
            if(transaction is null)
            {
                return StandardResponse<TransactionResponseDto>.Failed($"Transaction with invoice code: {invoiceCode} does exist.", 99);
            }

            var transactionDto = _mapper.Map<TransactionResponseDto>(transaction);

            return StandardResponse<TransactionResponseDto>.Success($"Transaction with invoice code: {invoiceCode}", transactionDto, 200);
        }

        public async Task<StandardResponse<TransactionResponseDto>> GetTransactionByProjectId(string projectId)
        {

            var transaction = await _unitOfWork.TransactionRepository.GetTransactionByProjectId(projectId);
            if (transaction is null)
            {
                return StandardResponse<TransactionResponseDto>.Failed($"Transaction with project id: {projectId} does exist.", 99);
            }

            var transactionDto = _mapper.Map<TransactionResponseDto>(transaction);

            return StandardResponse<TransactionResponseDto>.Success($"Transaction with invoice code: {projectId}", transactionDto, 200);

        }
    }
}
