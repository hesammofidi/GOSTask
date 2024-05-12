namespace Application.Dtos.OrderProductDtos
{
    public class OrderProductDto : IOrderProductDto
    {
        public int? Id { get; set; }
        public string? RoleName { get; set; }
        public string? SystemName { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
    }
}
