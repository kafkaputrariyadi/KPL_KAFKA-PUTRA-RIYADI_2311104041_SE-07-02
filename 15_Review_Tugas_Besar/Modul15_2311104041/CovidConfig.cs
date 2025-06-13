using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
namespace Modul15_2311104041
{

    public class CovidConfig
    {
        public string satuan_suhu { get; set; } = "celcius";
        public int batas_hari_deman { get; set; } = 14;
        public string pesan_ditolak { get; set; } = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
        public string pesan_diterima { get; set; } = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

        private const string configPath = "covid_config.json";

        public void LoadConfig()
        {
            if (File.Exists(configPath))
            {
                string jsonString = File.ReadAllText(configPath);
                var config = JsonSerializer.Deserialize<CovidConfig>(jsonString);
                if (config != null)
                {
                    this.satuan_suhu = config.satuan_suhu;
                    this.batas_hari_deman = config.batas_hari_deman;
                    this.pesan_ditolak = config.pesan_ditolak;
                    this.pesan_diterima = config.pesan_diterima;
                }
            }
        }

        public void UbahSatuan()
        {
            if (satuan_suhu == "celcius")
                satuan_suhu = "fahrenheit";
            else
                satuan_suhu = "celcius";
        }
    }
}