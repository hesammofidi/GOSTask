namespace Application.Models.Abstraction
{
    public class PagedList<TEntity>
    {
        private List<TEntity> _items = new();
        public IReadOnlyList<TEntity> Items => _items.AsReadOnly();
        public PagingData Paging { get; set; }
        public PagedList(IEnumerable<TEntity> items, int pageSize, int pageIndex, int totalRecordCount)
        {
            _items.AddRange(items);
            Paging = new PagingData(pageSize, pageIndex, totalRecordCount);
        }
    }
}
