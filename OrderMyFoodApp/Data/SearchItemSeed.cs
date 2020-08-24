using RestuarantSearchApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestuarantSearchApi.Data
{
    public class SearchItemSeed
    {

        public static async Task SeedAsync(SearchItemContext context)
        {
            if (!context.RestaurantDetails.Any())
            {
                context.RestaurantDetails.AddRange(GetPreconfiguredRestaurantDetailss());
                await context.SaveChangesAsync();
            }
            if (!context.SearchItems.Any())
            {
                context.SearchItems.AddRange(GetPreconfiguredSearchItems());
                await context.SaveChangesAsync();
            }

        }

        static IEnumerable<RestaurantDetails> GetPreconfiguredRestaurantDetailss()
        {
            return new List<RestaurantDetails>()
            {
                new RestaurantDetails(){ Name="Apple Restaurant"},
                 new RestaurantDetails(){ Name="Abc Restaurant"},
                  new RestaurantDetails(){ Name="Leaf Restaurant"},
                   new RestaurantDetails(){ Name="Athidi Restaurant"}
            };
        }
        static IEnumerable<SearchItem> GetPreconfiguredSearchItems()
        {
            return new List<SearchItem>()
            {
                new SearchItem(){ ItemName="Idly", ItemPrice=20, Quantity=2, RestaurantId=1, ItemPictureUrl="http://externalsearchbaseurltobereplaced/api/pic/1"},
                new SearchItem(){ ItemName="Dosa", ItemPrice=20, Quantity=2, RestaurantId=2, ItemPictureUrl="http://externalsearchbaseurltobereplaced/api/pic/2"},
                new SearchItem(){ ItemName="Puri", ItemPrice=20, Quantity=2, RestaurantId=1, ItemPictureUrl="http://externalsearchbaseurltobereplaced/api/pic/3"},
                new SearchItem(){ ItemName="Full Meals", ItemPrice=90, Quantity=1, RestaurantId=3, ItemPictureUrl="http://externalsearchbaseurltobereplaced/api/pic/4"},
                new SearchItem(){ ItemName="Meals", ItemPrice=80, Quantity=1, RestaurantId=4, ItemPictureUrl="http://externalsearchbaseurltobereplaced/api/pic/5"},
                new SearchItem(){ ItemName="Chicken Biryani", ItemPrice=120, Quantity=1, RestaurantId=2, ItemPictureUrl="http://externalsearchbaseurltobereplaced/api/pic/6"},
                new SearchItem(){ ItemName="Veg Biryani", ItemPrice=90, Quantity=1, RestaurantId=3, ItemPictureUrl="http://externalsearchbaseurltobereplaced/api/pic/7"},
                new SearchItem(){ ItemName="Mutton Biryani", ItemPrice=180, Quantity=1, RestaurantId=4, ItemPictureUrl="http://externalsearchbaseurltobereplaced/api/pic/8"}

            };
        }
    }
}
