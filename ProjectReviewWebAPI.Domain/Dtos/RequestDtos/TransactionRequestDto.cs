using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Dtos.RequestDtos
{
    public record TransactionRequestDto /*(string firstName, string lastName, string email, 
        string projectId, double amount);*/
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
        public string ProjectId { get; init; }
        [Column(TypeName = "Money")]
        public double Amount { get; init; }
    }
}
