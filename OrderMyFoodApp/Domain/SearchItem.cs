using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestuarantSearchApi.Domain
{
    //[Table("SearchItem")]
    public class SearchItem
    {
       // [Key]
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int ItemPrice { get; set; }
        public int Quantity { get; set; }
        public string ItemPictureUrl { get; set; }
       // [ForeignKey("RestaurantId")]
        public int RestaurantId { get; set; }
        public RestaurantDetails Restaurants { get; set; }

    }
}
