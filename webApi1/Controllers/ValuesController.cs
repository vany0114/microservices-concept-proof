using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Abstractions;
using webApi1.IntegrationEvents.Events;

namespace webApi1.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        Api1Context _context;
        private readonly IEventBus _eventBus;

        public ValuesController(Api1Context context, IEventBus eventBus)
        {
            _context = context;
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Entity1> Get()
        {
            return _context.Values.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Entity1 Get(string id)
        {
            return _context.Values.FirstOrDefault(x => x.Key == id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            _context.Values.Add(new Entity1 { Key = Guid.NewGuid().ToString(), Value = value });
            _context.SaveChanges();
        }

        [HttpPost("/api/othervalues")]
        public void OtherPost([FromBody]EntityValue value)
        {
            _context.Values.Add(new Entity1 { Key = value.Id, Value = value.Value });
            _context.SaveChanges();

            var @event = new CreatedTripIntegrationEvent(Guid.NewGuid().ToString(), new TripInformation(1, 2));
            _eventBus.Publish(@event);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var entity = _context.Values.FirstOrDefault(x => x.Key == id);
            _context.Values.Remove(entity);
            _context.SaveChanges();
        }
    }

    public class EntityValue
    {
        public string Id { get; set; }

        public string Value { get; set; }
    }
}
