using JurnalModul13_2311104041;

public class Program
{
    public static void Main(string[] args)
    {
        var pusatData1 = PusatDataSingleton.GetInstance();
        var pusatData2 = PusatDataSingleton.GetInstance();

        pusatData1.TambahData("Kafka");
        pusatData1.TambahData("Adit");
        pusatData1.TambahData("Bu Nia");

        Console.WriteLine("Data di pusatData2:");
        pusatData2.TampilkanSemuaData();

        pusatData2.HapusData(2);

        Console.WriteLine("\nSetelah penghapusan, data di pusatData1:");
        pusatData1.TampilkanSemuaData();

        Console.WriteLine($"\nJumlah data di pusatData1: {pusatData1.AmbilSemuaData().Count}");
        Console.WriteLine($"Jumlah data di pusatData2: {pusatData2.AmbilSemuaData().Count}");
    }
}
