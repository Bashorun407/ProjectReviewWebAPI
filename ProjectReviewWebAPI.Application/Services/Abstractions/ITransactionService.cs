﻿using ProjectReviewWebAPI.Domain.Dtos;
using ProjectReviewWebAPI.Domain.Dtos.RequestDtos;
using ProjectReviewWebAPI.Domain.Dtos.ResponseDto;
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
        Task<StandardResponse<(IEnumerable<TransactionResponseDto> transactions, MetaData pagingData)>> GetAllTransactionsAsync(TransactionRequestInputParameter parameter);
        Task<StandardResponse<TransactionResponseDto>> GetTransactionByProjectId(TransactionRequestDto transactionRequestDto);
    }
}