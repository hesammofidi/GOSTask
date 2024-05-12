namespace Application.Models.Abstraction
{
    public class PagingData
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalRecordCount { get; set; }
        public int PageCount => (int)Math.Ceiling((double)TotalRecordCount / PageSize);
        public bool HasNext => CurrentPage < PageCount;
        public bool HasPrevious => CurrentPage > 1;

        public PagingData(int pageSize, int pageIndex, int totalRecordCount)
        {
            PageSize = pageSize;
            CurrentPage = pageIndex;
            TotalRecordCount = totalRecordCount;
        }
    }
}
