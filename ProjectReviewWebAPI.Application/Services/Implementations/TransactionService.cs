using AutoMapper;
using Microsoft.Extensions.Logging;
using ProjectReviewWebAPI.Application.Services.Abstractions;
using ProjectReviewWebAPI.Domain.Dtos;
using ProjectReviewWebAPI.Shared.Dtos.RequestDtos;
using ProjectReviewWebAPI.Shared.Dtos.ResponseDto;
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
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly IProjectService _projectService;

        public TransactionService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<TransactionService> logger, IEmailService emailService, IUserService userService, IProjectService projectService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _emailService = emailService;
            _userService = userService;
            _projectService = projectService;
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

            //To retrieve user details from project database
            var result = await _projectService.GetByProjectId(transaction.ProjectId);
            var project = _mapper.Map<Project>(result);

            //Using the project details to retrieve project owner details from user database
            var projectOwnerRes = _userService.GetByUserId(project.ProjectOwnerId);
            var projectOwner = _mapper.Map<User>(projectOwnerRes);

            //email notification to project-owner 
            _emailService.SendEmailAsync(projectOwner.Email, "Project Payment Notification", $"Dear {projectOwner.FirstName},\n You have successfully paid for project-id :{project.Id}.\n Thank You.");

            //Using the project details to retrieve service-provider details from the database
            var serviceProviderRes = _userService.GetByUserId(project.ProjectOwnerId);
            var serviceProvider = _mapper.Map<User>(serviceProviderRes);
            //email notification to service-provider 
            _emailService.SendEmailAsync(projectOwner.Email, "Project Commencement Notification", $"Dear {serviceProvider.FirstName},\n You can commence with project-id :{project.Id}");

            var transactionDto = _mapper.Map<TransactionResponseDto>(transaction);

            return StandardResponse<TransactionResponseDto>.Success("New transaction added", transactionDto, 201); ;
        }

        public async Task<StandardResponse<PagedList<TransactionResponseDto>>> GetAllTransactionsAsync(TransactionRequestInputParameter parameter)
        {


            var result = await _unitOfWork.TransactionRepository.GetAll(parameter, false);

            if (!result.Any())
            {
                return StandardResponse<PagedList<TransactionResponseDto>>.Failed($"There are no projects yet", 99);
            }

            var transactionsDto = _mapper.Map<IEnumerable<TransactionResponseDto>>(result);
            var pagedList = new PagedList<TransactionResponseDto>(transactionsDto.ToList(), result.MetaData.TotalCount, parameter.PageNumber, parameter.PageSize);

            return StandardResponse<PagedList<TransactionResponseDto>>.Success("All transactions", pagedList, 200);
        }

        public async Task<StandardResponse<TransactionResponseDto>> GetTransactionByInvoiceCode(string invoiceCode)
        {
            var transaction = await _unitOfWork.TransactionRepository.GetTransactionByInvoiceCode(invoiceCode, false);
            if(transaction is null)
            {
                return StandardResponse<TransactionResponseDto>.Failed($"Transaction with invoice code: {invoiceCode} does exist.", 99);
            }

            var transactionDto = _mapper.Map<TransactionResponseDto>(transaction);

            return StandardResponse<TransactionResponseDto>.Success($"Transaction with invoice code: {invoiceCode}", transactionDto, 200);
        }

        public async Task<StandardResponse<TransactionResponseDto>> GetTransactionByProjectId(string projectId)
        {

            var transaction = await _unitOfWork.TransactionRepository.GetTransactionByProjectId(projectId, false);
            if (transaction is null)
            {
                return StandardResponse<TransactionResponseDto>.Failed($"Transaction with project id: {projectId} does exist.", 99);
            }

            var transactionDto = _mapper.Map<TransactionResponseDto>(transaction);

            return StandardResponse<TransactionResponseDto>.Success($"Transaction with invoice code: {projectId}", transactionDto, 200);

        }
    }
}
