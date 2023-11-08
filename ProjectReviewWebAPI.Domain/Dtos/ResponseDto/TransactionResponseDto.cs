using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Dtos.ResponseDto
{
    public record TransactionResponseDto /*(string firstName,  string lastName, string otherName, string projectId, 
        double amount, string invoiceCode);*/
    {
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? OtherName { get; init; }
        public string? ProjectId { get; init; }
        public double Amount { get; init; }
        public string? InvoiceCode { get; init; }
    }
}
