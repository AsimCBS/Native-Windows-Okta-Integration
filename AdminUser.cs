using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace WindowsRestAPI
{
    public class AdminUser
    {
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "UserName")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "FirstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "LastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "Email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "LocationGroup")]
        public string LocationGroup { get; set; }

        [JsonProperty(PropertyName = "LocationGroupId")]
        public string LocationGroupId { get; set; }

        [JsonProperty(PropertyName = "TimeZone")]
        public string TimeZone { get; set; }

        [JsonProperty(PropertyName = "Locale")]
        public string Locale { get; set; }

        [JsonProperty(PropertyName = "InitialLandingPage")]
        public string InitialLandingPage { get; set; }

        [JsonProperty(PropertyName = "LastLoginTimeStamp")]
        public string LastLoginTimeStamp { get; set; }
    }
}
