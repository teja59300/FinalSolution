using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestuarantSearchApi.ViewModels
{
    public class PaginatedItemViewModel<TEntity> where TEntity:class
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public long Count { get; set; }
        public IEnumerable<TEntity> Data { get; set; }
        public PaginatedItemViewModel(int pageIndex,int pageSize,long count,IEnumerable<TEntity> data)
        {
            this.PageSize = pageSize;
            this.PageIndex = pageIndex;
            this.Count = count;
            this.Data = data;
        }
    }
}
