using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace tpmodul7_1302204105
{
    class Driver
    {
        public static void Main(string[] args)
        {
            CovidConfig.ubahSatuan();
            CovidConfig data = CovidConfig.readJson();
            Console.WriteLine(data.satuan_suhu);
            Console.Write($"Berapa suhu badan anda saat ini ? Dalam nilai {data.satuan_suhu}: ");
            double suhu = Double.Parse(Console.ReadLine());
            Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam ? ");
            int hari = int.Parse(Console.ReadLine());
            //Console.WriteLine(hari);
            if(hari >= data.batas_hari_demam) {
                Console.WriteLine("1 "+data.pesan_ditolak);
            } else if(data.satuan_suhu == "celcius" && (suhu < 36.5 || suhu > 37.5)) {
                Console.WriteLine("2 " + data.pesan_ditolak);
            } else if(data.satuan_suhu == "fahrenheit" && (suhu < 97.7 || suhu > 99.5)) {
                Console.WriteLine("3 " + data.pesan_ditolak);
            }
            else{
                Console.WriteLine(data.pesan_diterima);
            }

        }
    }
}