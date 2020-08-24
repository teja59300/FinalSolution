using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMyFoodApp.Web.WebMvc.Models
{
    public class Search
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public List<SearchItem> Data { get; set; }
    }
}
