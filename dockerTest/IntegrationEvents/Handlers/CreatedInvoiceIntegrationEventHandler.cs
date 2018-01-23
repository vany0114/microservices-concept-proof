using dockerTest.IntegrationEvents.Events;
using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dockerTest.IntegrationEvents.Handlers
{
    public class CreatedInvoiceIntegrationEventHandler :
        IIntegrationEventHandler<CreatedInvoiceIntegrationEvent>
    {
        DockerTestContext _context;

        public CreatedInvoiceIntegrationEventHandler(DockerTestContext context)
        {
            _context = context;
        }

        public async Task Handle(CreatedInvoiceIntegrationEvent @event)
        {
            _context.Values.Add(new Entity1 { Key = @event.InvoiceId, Value = "CreatedInvoiceIntegrationEvent" });
            await _context.SaveChangesAsync();
        }
    }
}
