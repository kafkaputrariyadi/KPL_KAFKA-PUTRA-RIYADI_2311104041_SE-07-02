using Modul15_2311104041;
using System;

class Program
{
    static void Main(string[] args)
    {
        UserManager userManager = new UserManager();

        while (true)
        {
            Console.WriteLine("=== Menu ===");
            Console.WriteLine("1. Registrasi");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Keluar");
            Console.Write("Pilih opsi: ");
            string option = Console.ReadLine();

            if (option == "1")
            {
                Console.Write("Masukkan username: ");
                string username = Console.ReadLine();

                Console.Write("Masukkan password: ");
                string password = Console.ReadLine();

                if (userManager.Register(username, password, out string errorMsg))
                    Console.WriteLine("Registrasi berhasil!");
                else
                    Console.WriteLine($"Registrasi gagal: {errorMsg}");
            }
            else if (option == "2")
            {
                Console.Write("Masukkan username: ");
                string username = Console.ReadLine();

                Console.Write("Masukkan password: ");
                string password = Console.ReadLine();

                if (userManager.Login(username, password))
                {
                    Console.WriteLine("Login berhasil!");

                    CovidConfig config = new CovidConfig();
                    config.LoadConfig();
                    config.UbahSatuan();

                    Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {config.satuan_suhu}: ");
                    if (!double.TryParse(Console.ReadLine(), out double suhu))
                    {
                        Console.WriteLine("Input suhu tidak valid.");
                        continue;
                    }

                    Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
                    if (!int.TryParse(Console.ReadLine(), out int hariDemam))
                    {
                        Console.WriteLine("Input hari demam tidak valid.");
                        continue;
                    }

                    bool suhuNormal = false;
                    if (config.satuan_suhu == "celcius")
                        suhuNormal = suhu >= 36.5 && suhu <= 37.5;
                    else
                        suhuNormal = suhu >= 97.7 && suhu <= 99.5;

                    Console.WriteLine(suhuNormal && hariDemam < config.batas_hari_deman
                        ? config.pesan_diterima
                        : config.pesan_ditolak);
                }
                else
                {
                    Console.WriteLine("Login gagal: Username atau password salah.");
                }
            }
            else if (option == "3")
            {
                Console.WriteLine("Terima kasih.");
                break;
            }
            else
            {
                Console.WriteLine("Opsi tidak valid.");
            }
        }
    }
}
