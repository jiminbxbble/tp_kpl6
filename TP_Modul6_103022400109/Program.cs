using System;
using System.Diagnostics;

namespace TP_MODUL6_103022400109
{
    public class SayaMusicTrack
    {
        private int id;
        private int playCount;
        private string title;

        public SayaMusicTrack(string title)
        {
            Debug.Assert(title != null, "Precondition gagal: Judul lagu tidak boleh null.");
            Debug.Assert(title.Length <= 100, "Precondition gagal: Judul lagu maksimal 100 karakter.");

            this.title = title;
            this.playCount = 0;

            Random rnd = new Random();
            this.id = rnd.Next(10000, 100000);
        }

        public void IncreasePlayCount(int count)
        {
            Debug.Assert(count <= 10000000, "Precondition gagal: Penambahan play count maksimal 10.000.000 per pemanggilan.");

            Debug.Assert(count >= 0, "Precondition gagal: Penambahan tidak boleh negatif.");

            try
            {
                checked
                {
                    this.playCount += count;
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error Exception: Penambahan play count gagal karena melebihi batas maksimum integer (Overflow)!");
            }
        }

        public void PrintTrackDetails()
        {
            Console.WriteLine($"ID Lagu     : {this.id}");
            Console.WriteLine($"Judul Lagu  : {this.title}");
            Console.WriteLine($"Total Play  : {this.playCount}");
            Console.WriteLine("-------------------------------------------------");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== TESTING NORMAL ===");
            SayaMusicTrack track1 = new SayaMusicTrack("Hello Future - NCT Dream");
            track1.PrintTrackDetails();

            track1.IncreasePlayCount(5000000);
            track1.PrintTrackDetails();

            Console.WriteLine("\n=== TESTING EXCEPTION (OVERFLOW) ===");
            for (int i = 0; i < 300; i++)
            {
                track1.IncreasePlayCount(10000000);
            }
            track1.PrintTrackDetails();


            
        }
    }
}