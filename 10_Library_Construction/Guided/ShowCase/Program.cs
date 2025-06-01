using System;
using UtilityLibraries;

class Program
{
    static void Main(string[] args)
    {
        int rowCount = 0;

        while (true)
        {

            if (rowCount == 0 || rowCount >= 25)
                ResetConsole();

            Console.Write("Input your string: ");
            string input = Console.ReadLine();


            if (string.IsNullOrEmpty(input))
                break;

            bool isUppercase = input.StartsWithUpper();
            Console.WriteLine($"Input: {input,-30} | Begins with uppercase? : {(isUppercase ? "Yes" : "No")}\n");

            rowCount += 3;
        }


        void ResetConsole()
        {
            if (rowCount > 0)
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

            Console.Clear();
            Console.WriteLine("=== Cek Huruf Kapital ===");
            Console.WriteLine("Tekan <Enter> langsung untuk keluar.\n");
            rowCount = 3;
        }
    }
}