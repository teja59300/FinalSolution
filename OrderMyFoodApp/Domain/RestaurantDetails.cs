using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestuarantSearchApi.Domain
{
    [Table("RestaurantDetails")]
    public class RestaurantDetails
    {
        
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Cuisine { get;set; }
        public int Budget { get; set; }
        public decimal Rating { get; set; }
        public string PictureUrl { get; set; }

    }
}
