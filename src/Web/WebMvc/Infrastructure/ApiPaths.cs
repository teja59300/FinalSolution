using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMyFoodApp.Web.WebMvc.Infrastructure
{
    public class ApiPaths
    {
        public static class Basket
        {
            public static string GetBasket(string baseUri, string basketId)
            {
                return $"{baseUri}/{basketId}";
            }

            public static string UpdateBasket(string baseUri)
            {
                return baseUri;
            }

            public static string CleanBasket(string baseUri, string basketId)
            {
                return $"{baseUri}/{basketId}";
            }
        }

        public static class Order
        {
            public static string GetOrder(string baseUri, string orderId)
            {
                return $"{baseUri}/{orderId}";
            }

            //public static string GetOrdersByUser(string baseUri, string userName)
            //{
            //    return $"{baseUri}/userOrders?userName={userName}";
            //}
            public static string GetOrders(string baseUri)
            {
                return baseUri;
            }
            public static string AddNewOrder(string baseUri)
            {
                return $"{baseUri}/new";
            }
        }

        public static class Search
        {
            public static string GetAllSearchItems(string baseUri, int page, int take, int? restaurant)
            {
                var filterQs = "";

                if (restaurant.HasValue)
                {
                    var restaurantQs = (restaurant.HasValue) ? restaurant.Value.ToString() : "null";

                    filterQs = $"/restaurant/{restaurantQs}";
                }

                return $"{baseUri}items{filterQs}?pageIndex={page}&pageSize={take}";
            }

            public static string GetSearchItem(string baseUri, int id)
            {

                return $"{baseUri}/items/{id}";
            }
            public static string GetAllRestaurant(string baseUri)
            {
                return $"{baseUri}catalogRestaurant";
            }


        }

        public static class Review
        {
            public static string GetReviews(string baseUri,int id)
            {
                return $"{baseUri}/Items/{id}";
            }
            public static string CreateReview(string baseUri)
            {
                return $"{baseUri}/Items";
            }
            public static string UpdateReview(string baseUri)
            {
                return $"{baseUri}/Item";
            }
        }

    }
}
