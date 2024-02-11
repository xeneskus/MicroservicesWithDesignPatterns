using SagaOrchestrationBasedPattern.Shared.Interfaces;

namespace SagaOrchestrationBasedPattern.Shared.Events
{
    public class PaymentCompletedEvent : IPaymentCompletedEvent
    {
        public PaymentCompletedEvent(Guid correlationId)
        {
            CorrelationId = correlationId;
        }

        public Guid CorrelationId { get; }
    }
}
