﻿using EventSourcing.API.DTOs;
using EventSourcing.Shared.Events;
using EventStore.ClientAPI;

namespace EventSourcing.API.EventStores
{
    public class ProductStream : AbstractStream
    {
        public static string StreamName => "ProductStream";
        public static string GroupName => "agroup";
        //public static string GroupName => "replay"; 

        public ProductStream(IEventStoreConnection eventStoreConnection) : base(StreamName, eventStoreConnection)
        {
        }

        public void Created(CreateProductDto createProductDto)
        {
            Events.AddLast(new ProductCreatedEvent { Id = Guid.NewGuid(), Name = createProductDto.Name, Price = createProductDto.Price, Stock = createProductDto.Stock, UserId = createProductDto.UserId });
        }
        public void NameChanged(ChangeProductNameDto changeProductNameDto)
        {
            Events.AddLast(new ProductNameChangedEvent { ChangedName = changeProductNameDto.Name, Id = changeProductNameDto.Id });
        }

        public void PriceChanged(ChangeProductPriceDto changeProductPriceDto)
        {
            Events.AddLast(new ProductPriceChangedEvent() { ChangedPrice = changeProductPriceDto.Price, Id = changeProductPriceDto.Id });
        }

        public void Deleted(Guid id)
        {
            Events.AddLast(new ProductDeletedEvent { Id = id });
        }
    }
}
