using MassTransit;

namespace SagaOrchestrationBasedPattern.Shared.Interfaces
{
    public interface IStockReservedEvent : CorrelatedBy<Guid>
    {
       List<OrderItemMessage> OrderItems { get; set; }
    }
}
