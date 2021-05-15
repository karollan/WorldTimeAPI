using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WorldTimeAPI.AppSettings;
namespace WorldTimeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorldTimeController : ControllerBase
    {

        //WorldTimeAPI Settings
        private readonly WorldTimeAPISettings settings;

        public WorldTimeController(IOptions<WorldTimeAPISettings> options)
        {
            settings = options.Value;
        }

        // GET: api/worldtime
        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            string url = $"http://worldtimeapi.org/api/timezone/{settings.Area}/{settings.Location}/{settings.Region}";

            using (HttpClient client = new HttpClient())
            {
                string json;
                var response = client.GetAsync(url).Result;

                //If given url returns 404 get list of all timezones
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    url = $"http://worldtimeapi.org/api/timezone";
                    json = await client.GetStringAsync(url);
                    return json;
                }


                json = response.Content.ReadAsStringAsync().Result;
                return json;
            }
        }

    }


}
