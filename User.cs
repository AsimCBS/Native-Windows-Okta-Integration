using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace WindowsRestAPI
{

    public class User
    {
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "login")]
        public string Login { get; set; }

        [JsonProperty(PropertyName = "mobilePhone")]
        public string MobilePhone { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }

        [JsonProperty(PropertyName = "activated")]
        public string Activated { get; set; }

        [JsonProperty(PropertyName = "statusChanged")]
        public string StatusChanged { get; set; }

        [JsonProperty(PropertyName = "lastLogin")]
        public string LastLogin { get; set; }

        [JsonProperty(PropertyName = "lastUpdated")]
        public string LastUpdated { get; set; }

        [JsonProperty(PropertyName = "passwordChanged")]
        public string PasswordChanged { get; set; }
    }
}
