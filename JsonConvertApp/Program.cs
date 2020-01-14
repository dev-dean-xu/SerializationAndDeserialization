using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonConvertApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DeserializationMethods();
            Console.WriteLine();

            SerializationMethods();
        }

        static void DeserializationMethods()
        {
            using (var reader = new StreamReader("../../data.json"))
            {
                var json = reader.ReadToEnd();
                var report1 = JsonConvert.DeserializeObject<TaxReport>(json);
                Console.WriteLine($"TaxReport.Version is {GetVersion(report1.Version)}");

                var report2 = JsonConvert.DeserializeObject<TaxReportByInternal>(json);
                Console.WriteLine($"TaxReportByInternal.Version is {GetVersion(report2.Version)}");

                var report3 = JsonConvert.DeserializeObject<TaxReportByAttribute>(json);
                Console.WriteLine($"TaxReportByAttribute.Version is {GetVersion(report3.Version)}");

                var report4 = JsonConvert.DeserializeObject<TaxReportIgnore>(json);
                Console.WriteLine($"TaxReportIgnore.Version is {GetVersion(report4.Version)}");

                var report5 = JsonConvert.DeserializeObject<TaxReportByMethod>(json);
                Console.WriteLine($"TaxReportByMethod.Version is {GetVersion(report5.Version)}");
            }
        }

        static string GetVersion(string version)
        {
            return version ?? "null";
        }

        static void SerializationMethods()
        {
            var id = Guid.NewGuid().ToString();
            var name = "Profit and Loss";
            var url = "https://reporting/a22c12ce-7b22-49ff-a674-1a509552f6de";
            var order = 1;
            var version = "1";

            var report1 = new TaxReport {Id = id, Name = name, Order = order, Url = url, Version = version};
            var report2 = new TaxReportByInternal { Id = id, Name = name, Order = order, Url = url, Version = version };
            var report3 = new TaxReportByAttribute { Id = id, Name = name, Order = order, Url = url, Version = version };
            var report4 = new TaxReportIgnore { Id = id, Name = name, Order = order, Url = url, Version = version };
            var report5 = new TaxReportByMethod { Id = id, Name = name, Order = order, Url = url, Version = version };

            var json = JsonConvert.SerializeObject(report1);
            OutputJson("TaxReport", json);

            json = JsonConvert.SerializeObject(report2);
            OutputJson("TaxReportByInternal", json);

            json = JsonConvert.SerializeObject(report3);
            OutputJson("TaxReportByAttribute", json);

            json = JsonConvert.SerializeObject(report4);
            OutputJson("TaxReportIgnore", json);

            json = JsonConvert.SerializeObject(report5);
            OutputJson("TaxReportByMethod", json);

            json = SerializeByJObject(report1);
            OutputJson("Serialize TaxReport using JObject", json);
        }

        static void OutputJson(string typeName, string json)
        {
            Console.WriteLine($"The json of {typeName}: {json}");
            Console.WriteLine();
        }

        static string SerializeByJObject(TaxReport report)
        {
            var jo = JObject.FromObject(report);
            jo["Version"].Parent.Remove();

            return jo.ToString();
        }
    }
}
