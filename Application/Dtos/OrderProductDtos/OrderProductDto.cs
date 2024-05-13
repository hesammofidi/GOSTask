namespace Application.Dtos.OrderProductDtos
{
    public class OrderProductDto : IOrderProductDto
    {
        public int? Id { get; set; }
        public string? ProductName { get; set; }
        public string? OrderTitle { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
    }
}
