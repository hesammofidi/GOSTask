namespace Application.Models.Abstraction
{
    public class FilterData
    {
        public string? Filter { get; set; }
        public int? PageSize { get; set; }
        public int? PageIndex { get; set; }
        public string? Sort { get; set; }
    }
}
