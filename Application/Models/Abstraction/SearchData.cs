namespace Application.Models.Abstraction
{
    public class SearchData
    {
        public string? SearchText { get; set; }
        public int? PageSize { get; set; }
        public int? PageIndex { get; set; }
        public string? Sort { get; set; }
    }
}
