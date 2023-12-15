using ProjectReviewWebAPI.Domain.Dtos;
using ProjectReviewWebAPI.Shared.Dtos.RequestDtos;
using ProjectReviewWebAPI.Shared.Dtos.ResponseDto;
using ProjectReviewWebAPI.Shared.RequestParameter.Common;
using ProjectReviewWebAPI.Shared.RequestParameter.ModelParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Application.Services.Abstractions
{
    public interface ITransactionService
    {
        Task<StandardResponse<TransactionResponseDto>> AddTransaction(TransactionRequestDto transactionResquestDto);
        Task<StandardResponse<PagedList<TransactionResponseDto>>> GetAllTransactionsAsync(TransactionRequestInputParameter parameter);
        Task<StandardResponse<TransactionResponseDto>> GetTransactionByProjectId(string projectId);
        Task<StandardResponse<TransactionResponseDto>> GetTransactionByInvoiceCode(string invoiceCode);


    }
}
