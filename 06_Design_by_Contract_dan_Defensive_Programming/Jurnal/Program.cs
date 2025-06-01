using System;
using TJ_modul6;

namespace Modul6
{
    class Program
    {
        static void Main()
        {
            SayaTubeUser user = new SayaTubeUser("Kafka Putra Riyadi");

            for (int i = 1; i <= 3; i++)
            {
                user.AddVideo(new SayaTubeVideo("Tutorial C#"));
            }
            Console.Write("Masukkan jumlah play count yang ingin ditambahkan: ");
            int count;
            while (!int.TryParse(Console.ReadLine(), out count) || count < 0 || count > 25000000)
            {
                Console.WriteLine("Input tidak valid! Play count harus antara 0 dan 25 juta.");
                Console.Write("Masukkan kembali: ");
            }

            foreach (SayaTubeVideo video in user.GetVideos())
            {
                video.IncreasePlayCount(count);
            }

            user.PrintAllVideoPlaycount();
        }
    }
}
