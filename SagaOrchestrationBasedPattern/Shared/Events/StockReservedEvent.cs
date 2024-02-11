using SagaOrchestrationBasedPattern.Shared;
using SagaOrchestrationBasedPattern.Shared.Interfaces;

namespace SagaOrchestrationBasedPatternSharedd.Events
{
    public class StockReservedEvent : IStockReservedEvent
    {
        public StockReservedEvent(Guid correlationId)
        {
            CorrelationId = correlationId;
        }

        public List<OrderItemMessage> OrderItems { get; set; }

        public Guid CorrelationId { get; }
    }
}
