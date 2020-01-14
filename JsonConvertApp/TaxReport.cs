namespace JsonConvertApp
{
    public class TaxReport
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int Order { get; set; }
        public string Version { get; set; }
        public bool IsNew => Version == "2";
    }
}
