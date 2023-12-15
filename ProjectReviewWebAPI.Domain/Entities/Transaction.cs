using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [ForeignKey(nameof(Project))]
        public string ProjectId { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        [Column(TypeName = "Money")]
        public double Amount { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string InvoiceCode { get; set; }

        //Navigational Properties
        public IEnumerable<Project> Projects { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}
