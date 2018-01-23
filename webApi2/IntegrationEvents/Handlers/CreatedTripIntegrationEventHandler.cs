using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webApi2.IntegrationEvents.Events;
using webApi2.Model;

namespace webApi2.IntegrationEvents.Handlers
{
    public class CreatedTripIntegrationEventHandler :
        IIntegrationEventHandler<CreatedTripIntegrationEvent>
    {
        IApi2Repository _repository;
        readonly IEventBus _eventBus;

        public CreatedTripIntegrationEventHandler(IApi2Repository repository, IEventBus eventBus)
        {
            _repository = repository;
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }

        public async Task Handle(CreatedTripIntegrationEvent @event)
        {
            var entity = new Api2Model
            {
                UserId = @event.TripId + " from Service bus",
                UpdateDate = DateTime.Now,
                Locations = new List<Location>
                {
                    new Location{ Code = "A1", Description = "Test location 1", LocationId = 1 },
                    new Location{ Code = "A2", Description = "Test location 2", LocationId = 2 },
                    new Location{ Code = "A3", Description = "Test location 3", LocationId = 3 },
                }
            };
            await _repository.AddAsync(entity);

            var invoiceEvent = new CreatedInvoiceIntegrationEvent(Guid.NewGuid().ToString());
            _eventBus.Publish(invoiceEvent);
        }
    }
}
