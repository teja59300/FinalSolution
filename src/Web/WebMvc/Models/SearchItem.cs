using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMyFoodApp.Web.WebMvc.Models
{
    public class SearchItem
    {
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public int ItemPrice { get; set; }
        public int Quantity { get; set; }
        public string ItemPictureUrl { get; set; }
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Cuisine { get; set; }
        public int Budget { get; set; }
        public decimal Rating { get; set; }
    }
}
