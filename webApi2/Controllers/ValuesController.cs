using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webApi2.Model;

namespace webApi2.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        IApi2Repository _repository;

        public ValuesController(IApi2Repository repository)
        {
            _repository = repository;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Api2Model>> Get()
        {
            return await _repository.GetAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async void Post([FromBody]string value)
        {
            var entity = new Api2Model
            {
                UserId = value,
                UpdateDate = DateTime.Now,
                Locations = new List<Location>
                {
                    new Location{ Code = "A1", Description = "Test location 1", LocationId = 1 },
                    new Location{ Code = "A2", Description = "Test location 2", LocationId = 2 },
                    new Location{ Code = "A3", Description = "Test location 3", LocationId = 3 },
                }
            };
            await _repository.AddAsync(entity);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
