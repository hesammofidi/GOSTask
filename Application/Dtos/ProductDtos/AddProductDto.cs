namespace Application.Dtos.ProductDtos
{
    public class AddProductDto : IBaseProductDto
    {
        public int? Price { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}
