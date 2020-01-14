using Newtonsoft.Json;

namespace JsonConvertApp
{
    public class TaxReportIgnore
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int Order { get; set; }
        [JsonIgnore]
        public string Version { get; set; }
        public bool IsNew => Version == "2";
    }
}
