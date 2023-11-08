using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Entities
{
    public class ProfilePhoto
    {
        public int Id { get; set; }
        public DateTime DateAdded { get; set;}
        public Byte IsMain { get; set;}
        public string PublicId { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

    }
}
