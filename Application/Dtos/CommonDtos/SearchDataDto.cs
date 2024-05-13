namespace Application.Dtos.CommonDtos
{
    public class SearchDataDto
    {
        public string? SearchText { get; set; }
        public int? PageSize { get; set; }
        public int? PageIndex { get; set; }
        public string? Sort { get; set; }
    }
}
