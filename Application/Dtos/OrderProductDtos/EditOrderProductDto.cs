namespace Application.Dtos.OrderProductDtos
{
    public class EditOrderProductDto : IOrderProductDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
    }
}
