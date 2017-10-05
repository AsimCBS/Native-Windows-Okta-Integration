using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace WindowsRestAPI
{
    public class LoginSuccess
    {
        [JsonProperty(PropertyName = "expiresAt")]
        public string ExpiresAt { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "relayState")]
        public string RelayState { get; set; }

        [JsonProperty(PropertyName = "sessionToken")]
        public string SessionToken { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string UserId { get; set; }

        [JsonProperty(PropertyName = "passwordChanged")]
        public string PasswordChanged { get; set; }

        [JsonProperty(PropertyName = "login")]
        public string Login { get; set; }

        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "locale")]
        public string Locale { get; set; }

        [JsonProperty(PropertyName = "timeZone")]
        public string TimeZone { get; set; }
    }
}
