using System;

public class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        if (string.IsNullOrEmpty(title) || title.Length > 100)
            throw new ArgumentException("Judul video tidak boleh null dan maksimal 100 karakter.");

        this.id = new Random().Next(10000, 99999);
        this.title = title;
        this.playCount = 0;
    }
    public void IncreasePlayCount(int count)
    {
        if (count < 0 || count > 10000000)
            throw new ArgumentException("Penambahan play count maksimal 10.000.000 per panggilan.");

        try
        {
            checked
            {
                this.playCount += count;
            }
        }
        catch (OverflowException)
        {
            Console.WriteLine("Error: playCount melebihi batas integer!");
        }
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine($"\nID Video    : {id}");
        Console.WriteLine($"Judul Video : {title}");
        Console.WriteLine($"Play Count  : {playCount}");
    }
}

class Program
{
    static void Main()
    {

        Console.Write("Masukkan judul video: ");
        string judul = Console.ReadLine();

        SayaTubeVideo video = new SayaTubeVideo(judul);
        video.PrintVideoDetails();

        while (true)
        {
            Console.Write("\nMasukkan jumlah play count yang ingin ditambahkan (max 10.000.000): ");
            int count;
            if (int.TryParse(Console.ReadLine(), out count) && count > 0 && count <= 10000000)
            {
                video.IncreasePlayCount(count);
                video.PrintVideoDetails();
            }
            else
            {
                Console.WriteLine("Input tidak valid! Masukkan angka antara 1 - 10.000.000.");
            }

            Console.Write("\nTambahkan play count lagi? (y/n): ");
            string lanjut = Console.ReadLine().ToLower();
            if (lanjut != "y") break;
        }
    }
}
