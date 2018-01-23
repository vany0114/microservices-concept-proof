using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApi2.IntegrationEvents.Events
{
    public class CreatedInvoiceIntegrationEvent : IntegrationEvent
    {
        public string InvoiceId { get; }

        public CreatedInvoiceIntegrationEvent(string invoiceId)
        {
            InvoiceId = invoiceId;
        }
    }
}
