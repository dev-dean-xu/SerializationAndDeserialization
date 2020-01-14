using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonConvertApp
{
    public class TaxReportByMethod
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int Order { get; set; }
        public string Version { get; set; }
        public bool IsNew => Version == "1";

        public bool ShouldSerializeVersion()
        {
            return false;
        }
    }
}
