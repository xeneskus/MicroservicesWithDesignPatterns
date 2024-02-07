namespace Order.API.DTOs
{
    public class OrderCreateDto
    {

        public string BuyerId { get; set; } //alıcı
        public List<OrderItemDto> OrderItems { get; set; }
        public PaymentDto Payment { get; set; }
        public AddressDto Address { get; set; }
    }

    public class OrderItemDto
    {
        public int ProductId { get; set; }
        public int Count { get; set; } // kaç sipariş verildi
        public decimal Price { get; set; }
        
    }
    public class PaymentDto
    {
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string Expiration { get; set; }
        public string CVV { get; set; }
    }

    public class AddressDto
    {
        public string Line { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
    }
}
