using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Shared.Dtos.ResponseDto
{
    public record TransactionResponseDto 
    {
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? OtherName { get; init; }
        public string? ProjectId { get; init; }
        public double Amount { get; init; }
        public string? InvoiceCode { get; init; }
    }
}
