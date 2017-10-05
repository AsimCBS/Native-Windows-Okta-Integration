using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace WindowsRestAPI
{
    public class App
    {
        [JsonProperty(PropertyName = "Id")]
        public string AppID { get; set; }

        [JsonProperty(PropertyName = "ApplicationName")]
        public string AppName { get; set; }

        [JsonProperty(PropertyName = "AppType")]
        public string AppType { get; set; }

        [JsonProperty(PropertyName = "AppVersion")]
        public string AppVersion { get; set; }

        [JsonProperty(PropertyName = "Status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "Platform")]
        public string Platform { get; set; }

        [JsonProperty(PropertyName = "ApplicationSize")]
        public string AppSize { get; set; }
    }
}
