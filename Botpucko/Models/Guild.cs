using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botpucko.Models
{
    public class Guild
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        public SessionDate Date { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }

    public class SessionDate
    {
        public DayOfWeek Day { get; set; }
        public TimeOnly Time { get; set; }
    }
}
