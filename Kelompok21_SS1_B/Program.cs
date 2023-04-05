using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kelompok21_SS1_B
{
    class Program
    {
        static void Main(string[] args)
        {
            Program pr = new Program();
            while (true)
            {
                Console.WriteLine("Koneksi Ke Database\n");
                Console.WriteLine("Masukan User ID : ");
                string user = Console.ReadLine();
                Console.WriteLine("Masukan Password :");
                string pass = Console.ReadLine();
                Console.WriteLine("Masukkan Database Tujuan :");
                string db = Console.ReadLine();
                Console.Write("\nKetik K untuk Terhubung ke Database: ");
                char chr = Convert.ToChar(Console.ReadLine());
                
            }
        }
    }
}
