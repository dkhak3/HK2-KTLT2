using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE1_CSC106055_05
{
    class Câu_2
    {
        struct ThongTin
        {
            public string hoTen;
            public string maDinhDanh;
            public DateTime ngaySinh;

            public ThongTin(string hoTen, string maDinhDanh, DateTime ngaySinh)
            {
                this.hoTen = hoTen;
                this.maDinhDanh = maDinhDanh;
                this.ngaySinh = ngaySinh;
            }
        }
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            int n = 0;

            Console.Write("Nhập vào số lượng thông tin: ");
            n = int.Parse(Console.ReadLine());

            ThongTin[] arr;

            arr = NhapMang(n);
            Console.WriteLine();

            XuatMang(arr);

        }

        private static void XuatMang(ThongTin[] arr)
        {
            Console.WriteLine("-------------------");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Thông tin người thứ {i + 1}");
                XuatThongTin(arr[i]);

                Console.WriteLine();
            }
        }

        private static void XuatThongTin(ThongTin thongTin)
        {
            Console.WriteLine($"Họ tên:  {thongTin.hoTen}");
            Console.WriteLine($"Mã định danh:  {thongTin.maDinhDanh}");
            Console.WriteLine($"Ngày sinh:  {thongTin.ngaySinh}");
        }

        private static ThongTin[] NhapMang(int n)
        {
            ThongTin[] arr = new ThongTin[n];

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Nhập thông tin người thứ {i + 1}");
                NhapThongTin(out arr[i]);

                Console.WriteLine();
            }
            return arr;
        }

        private static void NhapThongTin(out ThongTin thongTin)
        {
            string tam = string.Empty;

            // Tên không có ký tự số, viết hoa đầu từ, giới hạn 30 kí tự
            do
            {
                Console.Write($"Nhập họ tên: ");
                tam = Console.ReadLine();
            } while (tam.Length > 30);
            thongTin.hoTen = XuLyChuoiTen(tam);

            // Mã định danh giới hạn 12 kí tự
            do
            {
                Console.Write("Nhập mã định danh: ");
                thongTin.maDinhDanh = Console.ReadLine();
            } while (thongTin.maDinhDanh.Length < 12);

            // Ngày sinh dưới 2004, ngày tháng năm hợp lệ
            do
            {
                Console.Write("Nhập ngày sinh: ");
                thongTin.ngaySinh = DateTime.Parse(Console.ReadLine());
            } while (thongTin.ngaySinh.Year < 2004);

        }

        private static string XuLyChuoiTen(string tam)
        {
            tam = XuLySo(tam);
            tam = XuLyChuoi(tam);

            return tam;
        }

        private static string XuLyChuoi(string tam)
        {
            tam = tam.Trim();
            tam = tam.ToLower();

            while (tam.Contains("  "))
            {
                tam = tam.Replace("  ", " ");
            }

            string[] arr = tam.Split(' ');
            string hoTen = string.Empty;

            for (int i = 0; i < arr.Length; i++)
            {
                hoTen += arr[i].Substring(0, 1).ToUpper() + arr[i].Substring(1) + " ";
            }

            hoTen = hoTen.TrimEnd();

            return hoTen;
        }

        private static string XuLySo(string tam)
        {
            for (int i = 0; i < tam.Length; i++)
            {
                if (tam[i] >= '0' && tam[i] <= '9')
                {
                    tam = tam.Remove(i);
                }
            }
            return tam;
        }
    }
}
