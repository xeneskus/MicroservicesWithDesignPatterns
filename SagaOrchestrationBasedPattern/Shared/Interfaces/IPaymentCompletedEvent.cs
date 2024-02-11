using MassTransit;

namespace SagaOrchestrationBasedPattern.Shared.Interfaces
{
    public interface IPaymentCompletedEvent : CorrelatedBy<Guid>
    {
    }
}
