namespace SagaOrchestrationBasedPattern.Shared.Interfaces
{
    public interface IOrderRequestFailedEvent
    {
        public int OrderId { get; set; } //hangi sipariş fail oldu
        public string Reason { get; set; } //neden oldu
    }
}
