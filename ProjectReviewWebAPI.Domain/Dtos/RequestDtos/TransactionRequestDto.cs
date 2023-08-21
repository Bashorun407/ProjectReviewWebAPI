using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Dtos.RequestDtos
{
    public class TransactionRequestDto
    {
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string OtherName { get; set; }
        private string Email { get; set; }
        private string ProjectId { get; set; }
        [Column(TypeName = "Money")]
        private double Amount { get; set; }
        private string InvoiceCode { get; set; }
    }
}
