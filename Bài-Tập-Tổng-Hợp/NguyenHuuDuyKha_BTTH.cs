using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bài_Tập_Tổng_Hợp
{
    class NguyenHuuDuyKha_BTTH
    {
        struct SinhVien
        {
            public string maSinhVien;
            public string hoTen;
            public DateTime ngaySinh;
            public double diemTBTotNghiep;
            public double[,] bangDiem;

            public SinhVien(string maSinhVien, string hoTen, DateTime ngaySinh, double diemTBTotNghiep, double[,] bangDiem)
            {
                this.maSinhVien = maSinhVien;
                this.hoTen = hoTen;
                this.ngaySinh = ngaySinh;
                this.diemTBTotNghiep = diemTBTotNghiep;
                this.bangDiem = bangDiem;
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            int n = 0;
            Console.Write($"Nhập số lượng sinh viên: ");
            n = int.Parse(Console.ReadLine());

            SinhVien[] arr;

            arr = NhapMang(n);
            Console.WriteLine();

            XuatMang(arr);
        }

        private static void XuatMang(SinhVien[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Thông tin sinh viên thứ {i + 1}");
                XuatThongTin(arr[i]);

                Console.WriteLine();
            }
        }

        private static void XuatThongTin(SinhVien sinhVien)
        {
            Console.WriteLine("******************");
            Console.WriteLine("BANG DIEM TONG KET");
            Console.WriteLine("******************");

            Console.WriteLine("Mã sinh viên: " + sinhVien.maSinhVien);
            Console.WriteLine("Họ tên: " + sinhVien.hoTen);
            Console.WriteLine("Ngày sinh: " + sinhVien.ngaySinh);

            Console.WriteLine("Xếp loại: " + XepLoai(sinhVien.diemTBTotNghiep));

            Console.WriteLine("Điểm trung bình chi tiết: ");
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{sinhVien.bangDiem[j, i]:0.0}\t");
                }
                Console.WriteLine();
            }
        }

        private static string XepLoai(double diem)
        {
            if (diem >= 5)
            {
                return diem >= 8 ? "Giỏi" : diem > 7 ? "Khá" : "Trung bình";
            }
            else
            {
                return "Yếu";
            }
        }

        private static SinhVien[] NhapMang(int n)
        {
            SinhVien[] arr = new SinhVien[n];

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Nhập thông tin sinh viên thứ {i + 1}");
                NhapThongTin(out arr[i]);

                Console.WriteLine();
            }
            return arr;
        }

        private static void NhapThongTin(out SinhVien sinhVien)
        {
            string tam = string.Empty;

            do
            {
                Console.Write("Nhập mã sinh viên: ");
                tam = Console.ReadLine();
            } while (XuLyMaSV(tam).Length < 11);
            sinhVien.maSinhVien = XuLyMaSV(tam);

            do
            {
                Console.Write("Nhập họ tên: ");
                tam = Console.ReadLine();
            } while (XuLyChuoiTen(tam).Length > 30);
            sinhVien.hoTen = XuLyChuoiTen(tam);

            do
            {
                Console.Write("Nhập ngày sinh: ");
                sinhVien.ngaySinh = DateTime.Parse(Console.ReadLine());
            } while (sinhVien.ngaySinh.Year < 1900);

            int temp = 1;
            Console.WriteLine("Nhập vào điểm TB các kỳ: ");
            sinhVien.bangDiem = new double[3, 2];
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Năm {i + 1} ");
                for (int j = 0; j < 2; j++)
                {
                    do
                    {
                        Console.WriteLine($"HK {temp}: ");
                        sinhVien.bangDiem[i, j] = double.Parse(Console.ReadLine());
                    } while (sinhVien.bangDiem[i, j] < 0 || sinhVien.bangDiem[i, j] > 10);
                    temp++;
                }
                temp = 1;
            }

            sinhVien.diemTBTotNghiep = DiemTBTN(sinhVien.bangDiem);
        }

        private static double DiemTBTN(double[,] bangDiem)
        {
            double trungBinhTotNghiep = 0; // dữ liệu của điểm TBTN
            for (int i = 0; i < 3; i++)
            {
                trungBinhTotNghiep += DiemTBTungNam(bangDiem[i, 0], bangDiem[i, 1]);
            }
            return trungBinhTotNghiep / 3;
        }

        private static double DiemTBTungNam(double HK1, double HK2)
        {
            return (HK1 + HK2) / 2;
        }

        private static string XuLyChuoiTen(string tam)
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

        private static string XuLyMaSV(string tam)
        {
            tam = XoaKhoangTrang(tam);

            return tam;
        }

        private static string XoaKhoangTrang(string tam)
        {
            while (tam.Contains(" "))
            {
                tam = tam.Replace(" ", "");
            }
            return tam;
        }
    }
}
