using dockerTest.IntegrationEvents.Events;
using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dockerTest.IntegrationEvents.Handlers
{
    public class CreatedTripIntegrationEventHandler :
        IIntegrationEventHandler<CreatedTripIntegrationEvent>
    {
        DockerTestContext _context;

        public CreatedTripIntegrationEventHandler(DockerTestContext context)
        {
            _context = context;
        }

        public async Task Handle(CreatedTripIntegrationEvent @event)
        {
            _context.Values.Add(new Entity1 { Key = @event.TripId, Value = "CreatedTripIntegrationEvent" });
            await _context.SaveChangesAsync();
        }
    }
}
