using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datetime
{
    class BT4
    {
        struct NhanVien
        {
            public string hoTen;
            public double luongCoBan;
            public DateTime ngaySinh;
            public double heSoLuong;

            public NhanVien(string hoTen, DateTime ngaySinh, double luongCoBan, double heSoLuong)
            {
                this.hoTen = hoTen;
                this.ngaySinh = ngaySinh;
                this.luongCoBan = luongCoBan;
                this.heSoLuong = heSoLuong;
            }
        }
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Nhập vào số lượng nhân viên: ");
            int n = int.Parse(Console.ReadLine());

            NhanVien[] arr = new NhanVien[n];

            NhapMang(arr);

            LietKeNhanVienSinhTrongQuy1(arr);
        }

        static void LietKeNhanVienSinhTrongQuy1(NhanVien[] arr)
        {
            Console.WriteLine("Họ tên nhân viên sinh trong quý 1");
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].ngaySinh.Month <= 3 && arr[i].ngaySinh.Month <= 3)
                {
                    Console.WriteLine(arr[i].hoTen);
                }
            }
        }

        static void NhapMang(NhanVien[] arr)
        {
            string hoTen;
            DateTime ngaySinh;
            double luongCoBan;
            double heSoLuong;
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Nhập nhân viên thứ {i}");

                Console.Write("Nhập họ tên: ");
                hoTen = Console.ReadLine();

                Console.Write("Nhập ngày-tháng-năm sinh: ");
                ngaySinh = DateTime.Parse(Console.ReadLine());

                Console.Write("Nhập lương cơ bản: ");
                luongCoBan = double.Parse(Console.ReadLine());

                Console.Write("Nhập hệ số lương: ");
                heSoLuong = double.Parse(Console.ReadLine());

                Console.WriteLine();
                arr[i] = new NhanVien(hoTen, ngaySinh, luongCoBan, heSoLuong);
            }
        }
    }
}
