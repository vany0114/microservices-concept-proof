using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace dockerTest.Pages
{
    public class IndexModel : PageModel
    {
        DockerTestContext _context;
        private readonly IOptionsSnapshot<AppSettings> _settings;

        public IndexModel(IOptionsSnapshot<AppSettings> settings, DockerTestContext context)
        {
            _settings = settings;
            _context = context;
        }

        public void OnGet()
        {
            _context.Values.Add(new Entity1 { Key = Guid.NewGuid().ToString(), Value = $"New acces at {DateTime.Now}" });
            _context.SaveChanges();

            var client = new HttpClient();
            var data = new { Id = Guid.NewGuid().ToString(), Value = "something" };

            var webApi1Url = $"{_settings.Value.Webapi1Url}/api/othervalues";
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, webApi1Url);
            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(data), System.Text.Encoding.UTF8, "application/json");
            var response = client.SendAsync(requestMessage).Result;
        }
    }
}
