namespace Application.Dtos.ProductDtos
{
    public class ProductInfoDto : IBaseProductDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public int? Price { get; set; }
    }
}
