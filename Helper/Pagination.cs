using System.Collections.Generic;
namespace maghsadAPI.Helper
{
    public class  Pagination<T> where T : class
    {
        public Pagination(int pageindex, int pagesize, int count, IReadOnlyList<T> data)
        {
            PageIndex = pageindex;
            PageSize = pagesize;
            Count = count;
            Data = data;
        }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public IReadOnlyList<T> Data { get; set; }
        
    }
}