using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Entities
{
    public class Rating : BaseEntity
    {
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public int StarRating { get; set; }
        public int RateCount { get; set; }
        public double AverageRating { get; set; }

        //Navigational property
        public List<User> Users { get; set; }

    }
}
