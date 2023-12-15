using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Entities
{
    public class Comment : BaseEntity
    {
        [ForeignKey(nameof(User))]
        public string? UserId { get; set; }
        public string? Comments { get; set; }

    }
}
