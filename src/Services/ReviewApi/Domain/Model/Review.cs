using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApi.Domain.Model
{
    public class Review
    {
        public int ReviewId { get; set; }
        public decimal Rating { get; set; }
        public string Comment { get; set; }
        public int UserId { get; set; }
        public DateTime ReviewDate { get; set; }
        public int RestaurantId { get; set; }


    }
}

