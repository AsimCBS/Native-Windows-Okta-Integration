using Newtonsoft.Json;

namespace WindowsRestAPI
{

    public class Group
    {
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "users")]
        public string Users { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

    }
}
