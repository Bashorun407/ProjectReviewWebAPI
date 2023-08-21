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
        private string UserId { get; set; }
        private int StarRating { get; set; }
        private int RateCount { get; set; }
        private double AverageRating { get; set; }

        //Navigational property
        private List<User> Users { get; set; }

    }
}
