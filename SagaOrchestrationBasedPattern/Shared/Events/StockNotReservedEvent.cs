﻿using Shared.Interfaces;

namespace SagaOrchestrationBasedPattern.Shared.Events
{
    public class StockNotReservedEvent : IStockNotReservedEvent
    {
        public StockNotReservedEvent(Guid correlationId)
        {
            CorrelationId = correlationId;
        }
        public string Reason { get; set; }

        public Guid CorrelationId {get; }
    }
}
