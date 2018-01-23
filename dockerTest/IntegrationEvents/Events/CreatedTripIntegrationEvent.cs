using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dockerTest.IntegrationEvents.Events
{
    public class CreatedTripIntegrationEvent : IntegrationEvent
    {
        public string TripId { get; }
        public TripInformation TripInformation { get; }

        public CreatedTripIntegrationEvent(string tripId,
            TripInformation tripInformation)
        {
            TripId = tripId;
            TripInformation = tripInformation;
        }
    }

    public class TripInformation
    {
        public int Property1 { get; }
        public int Property2 { get; }

        public TripInformation(int property1, int property2)
        {
            Property1 = property1;
            Property2 = property2;
        }
    }
}
