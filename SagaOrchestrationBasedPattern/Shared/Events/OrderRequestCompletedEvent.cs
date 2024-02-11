using SagaOrchestrationBasedPattern.Shared.Interfaces;

namespace SagaOrchestrationBasedPattern.Shared.Events
{
    public class OrderRequestCompletedEvent : IOrderRequestCompletedEvent
    {
        public int OrderId { get; set ; }
    }
}
