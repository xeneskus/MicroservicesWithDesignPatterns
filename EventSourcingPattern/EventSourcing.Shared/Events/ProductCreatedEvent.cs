namespace EventSourcing.Shared.Events
{
    public class ProductCreatedEvent : IEvent
    {
        public Guid Id { get; set; } //veritabanımız çökerse geri verileri kullanmak için idyi kendimiz verdik
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int UserId { get; set; } // hangi kullanıcıya ait
    }
}
