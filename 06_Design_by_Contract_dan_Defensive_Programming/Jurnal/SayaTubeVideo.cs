using System;
using System.Diagnostics;

namespace TJ_modul6
{
    public class SayaTubeVideo
    {
        private int id;
        private string title;
        private int playCount;

        public SayaTubeVideo(string title)
        {
            Debug.Assert(title != null, "Judul video tidak boleh null");
            Debug.Assert(title.Length <= 200, "Judul video maksimal 200 karakter");

            this.id = new Random().Next(10000, 99999);
            this.title = title;
            this.playCount = 0;
        }

        public void IncreasePlayCount(int count)
        {
            Debug.Assert(count > 0, "Play count tidak boleh negatif");
            Debug.Assert(count <= 25000000, "Play count tidak boleh lebih dari 25 juta");

            try
            {
                checked
                {
                    if (this.playCount + count > int.MaxValue)
                    {
                        throw new OverflowException("Play count melebihi batas maksimum integer!");
                    }
                    this.playCount += count;
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void PrintVideoDetails()
        {
            Console.WriteLine($"ID Video: {id}");
            Console.WriteLine($"Judul Video: {title}");
            Console.WriteLine($"Total Play Count: {playCount}");
            Console.WriteLine();
        }

        public int GetPlayCount()
        {
            return playCount;
        }
    }
}
