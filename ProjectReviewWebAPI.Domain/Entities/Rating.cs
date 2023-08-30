using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReviewWebAPI.Domain.Entities
{
    public class Rating : BaseEntity
    {
        //[ForeignKey(nameof(User))]
        public string UserId { get; set; }
        [Range(1, 5)]
        public int StarRating { get; set; }
        public int RateCount { get; set; }
        public double AverageRating { get; set; }

        //Navigational property
        //public User Users { get; set; }

    }
}
