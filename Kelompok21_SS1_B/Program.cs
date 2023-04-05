using System;
using System.Data.SqlClient;
using System.Data;

namespace Kelompok21_SS1_B
{
    class Program
    {
        static void Main(string[] args)
        {
            Program pr = new Program();
            while (true)
            {
                try
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
                    switch (chr)
                    {
                        case 'K':
                            {
                                SqlConnection conn = null;
                                string strKoneksi = "Data source =DESKTOP-4IT269M\\ADINDANURHAYATI; " + "initial catalog = {0};" + "User ID = {1}; password = {2}";
                                conn = new SqlConnection(string.Format(strKoneksi, db, user, pass));
                                conn.Open();
                                Console.Clear();
                                while (true)
                                {
                                    try
                                    {
                                        Console.WriteLine("\nMenu");
                                        Console.WriteLine("1. Melihat Seluruh Data");
                                        Console.WriteLine("2. Tambah Data");
                                        Console.WriteLine("3. Keluar");
                                        Console.Write("\nEnter Your Choice (1-3): ");
                                        char ch = Convert.ToChar(Console.ReadLine());
                                        switch (ch)
                                        {
                                            case '1':
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("DATA MAHASISWA BARU\n");
                                                    Console.WriteLine();
                                                    pr.baca(conn);
                                                    conn.Close();
                                                }
                                                break;
                                            case '2':
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("INPUT DATA MAHASISWA BARU\n");
                                                    Console.WriteLine("Masukan Id Mahasiswa :");
                                                    string Id_Mhs = Console.ReadLine();
                                                    Console.WriteLine("Masukan Nama Mahasiswa :");
                                                    string Nama_Mhs = Console.ReadLine();
                                                    Console.WriteLine("Masukan Id_Peminatan: ");
                                                    string Id_Peminatan = Console.ReadLine();
                                                    Console.WriteLine("Masukkan Asal Provinsi   :");
                                                    string Provinsi = Console.ReadLine();
                                                    Console.WriteLine("Masukkan Asal Kota   :");
                                                    string Kota = Console.ReadLine();
                                                    Console.WriteLine("Masukkan No Telepon : ");
                                                    string No_Telp = Console.ReadLine();
                                                    try
                                                    {
                                                        pr.insert(Id_Mhs, Nama_Mhs, Id_Peminatan, Provinsi, Kota, No_Telp, conn);
                                                        conn.Close();
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("\nAnda tidak memiliki " + "Akses untuk menambah data");
                                                    }
                                                }
                                                break;
                                            case '3':
                                                conn.Close();
                                                return;
                                            default:
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("\nInvalid option");
                                                }
                                                break;

                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("\nCheck for the value entered.");
                                    }
                                }
                            }
                        default:
                            {
                                Console.WriteLine("\nInvalid Option");
                            }
                            break;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Tidak Dapat Mengakses Database Menggunakan User Tersebut\n");
                    Console.ResetColor();
                }
            }
        }
        public void baca(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("Select * From HRD.Mahasiswa", con);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                for (int i = 0; i < r.FieldCount; i++)
                {
                    Console.WriteLine(r.GetValue(i));
                }
                Console.WriteLine();
            }
            r.Close();
        }
        public void insert(string Id_Mhs, string Nama_Mhs, string Id_Peminatan, string Provinsi, string Kota, string No_Telp,
            SqlConnection con)
        {
            string str = "";
            str = "insert into MAHASISWA (Id_Mhs,Nama_Mhs,Id_Peminatan,Provinsi,Kota,No_Telp) "
                + "values(@IdMhs,@NmaMhs,@IdPn,@Pr,@Ko,@PhoneMhs)";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("IdMhs", Id_Mhs));
            cmd.Parameters.Add(new SqlParameter("Nama_Mhs", Nama_Mhs));
            cmd.Parameters.Add(new SqlParameter("Id_Peminatan", Id_Peminatan));
            cmd.Parameters.Add(new SqlParameter("Provinsi", Provinsi));
            cmd.Parameters.Add(new SqlParameter("Kota", Kota));
            cmd.Parameters.Add(new SqlParameter("No_Telp", No_Telp));
            cmd.ExecuteNonQuery();
            Console.WriteLine("Data Berhasil Ditambahkan");
        }
    }
}