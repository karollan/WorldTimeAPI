using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldTimeAPI.AppSettings
{
    public class WorldTimeAPISettings
    {
        public string Area { get; set; }
        public string Location { get; set; }
        public string Region { get; set; }
    }
}
