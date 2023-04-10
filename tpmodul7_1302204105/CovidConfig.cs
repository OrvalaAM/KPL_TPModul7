using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;


namespace tpmodul7_1302204105
{
    public class CovidConfig
    {
        public String satuan_suhu { get; set; }
        public int batas_hari_demam { get; set; }
        public String pesan_ditolak { get; set; }
        public String pesan_diterima { get; set; }

        public static CovidConfig readJson()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string dataStr = File.ReadAllText(path + "/covid_config.json");
            return JsonSerializer.Deserialize<CovidConfig>(dataStr);
        }
        public static void ubahSatuan()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string dataStr = File.ReadAllText(path + "/covid_config.json");
            var obj = CovidConfig.readJson();
            Newtonsoft.Json.JsonConvert.PopulateObject(dataStr, obj);
            //dynamic obj = Newtonsoft.Json.JsonConvert.DeserializeObject(dataStr);
            if (obj.satuan_suhu == "celcius")
            {
                obj.satuan_suhu = "fahrenheit";
            }
            else if (obj.satuan_suhu == "fahrenheit")
            {
                obj.satuan_suhu = "celcius";
            }
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(obj, options);
            string fileFullPath = path + "/covid_config.json";

            File.WriteAllText(fileFullPath, jsonString);
            //Console.WriteLine(obj["satuan_suhu"]);
            // string output = Newtonsoft.Json.JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
            //File.WriteAllText(path + "/covid_config.json", output);
        }
    }
}
