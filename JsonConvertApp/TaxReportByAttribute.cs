using Newtonsoft.Json;

namespace JsonConvertApp
{
    public class TaxReportByAttribute
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int Order { get; set; }
        [JsonIgnore] public string Version { get; set; }

        [JsonProperty(nameof(Version))]
        private string VersionSetter
        {
            set => Version = value;
        }

        public bool IsNew => Version == "2";
    }
}
