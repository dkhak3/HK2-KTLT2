using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EXE3
{
    class NguyenHuuDuyKha_Cau2
    {
        struct CauThu
        {
            public string hoTen;
            public DateTime ngaySinh;
            public int soAo;
            public int banThang;

            public CauThu(string hoTen, DateTime ngaySinh, int soAo, int banThang)
            {
                this.hoTen = hoTen;
                this.ngaySinh = ngaySinh;
                this.soAo = soAo;
                this.banThang = banThang;
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int n = 0;
            CauThu[] arr;

            Console.Write("Nhập vào số lượng cầu thủ: ");
            n = int.Parse(Console.ReadLine());

            arr = NhapMang(n);

            XuatMang(arr);

            GhiFile(arr);

            GhiFileTimCauThu(arr);
        }

        private static void GhiFileTimCauThu(CauThu[] arr)
        {
            int n = 0;
            Console.Write("Nhập vào số áo cầu thủ cần tìm: ");
            n = int.Parse(Console.ReadLine());

            try
            {
                StreamWriter ghiFile = new StreamWriter(@"D:\NguyenHuuDuyKha_File.TXT");
                using (ghiFile)
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (arr[i].soAo == n)
                        {
                            ghiFile.WriteLine("Họ tên: " + arr[i].hoTen);
                            ghiFile.WriteLine("Ngày sinh: " + arr[i].ngaySinh.ToString("dd/MM/yyyy"));
                            ghiFile.WriteLine("Số áo: " + arr[i].soAo);
                            ghiFile.WriteLine("Số bàn thắng: " + arr[i].banThang);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static void GhiFile(CauThu[] arr)
        {
            try
            {
                StreamWriter ghiFile = new StreamWriter("DanhSach.txt");
                using (ghiFile)
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        ghiFile.WriteLine("Họ tên: " + arr[i].hoTen);
                        ghiFile.WriteLine("Ngày sinh: " + arr[i].ngaySinh.ToString("dd/MM/yyyy"));
                        ghiFile.WriteLine("Số áo: " + arr[i].soAo);
                        ghiFile.WriteLine("Số bàn thắng: " + arr[i].banThang);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static void XuatMang(CauThu[] arr)
        {
            Console.WriteLine("-----------------");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Xuất cầu thủ thứ {i + 1}");
                XuatCauThu(arr[i]);

                Console.WriteLine();
            }
        }

        private static void XuatCauThu(CauThu cauThu)
        {
            Console.WriteLine("Họ tên: " + cauThu.hoTen);
            Console.WriteLine("Ngày sinh: " + cauThu.ngaySinh.ToString("dd/MM/yyyy"));
            Console.WriteLine("Số áo: " + cauThu.soAo);
            Console.WriteLine("Số bàn thắng: " + cauThu.banThang);
        }


        private static CauThu[] NhapMang(int n)
        {
            CauThu[] arr = new CauThu[n];

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Nhập cầu thủ thứ {i + 1}");
                NhapCauThu(out arr[i]);

                Console.WriteLine();
            }
            return arr;
        }

        private static void NhapCauThu(out CauThu cauThu)
        {
            string tam = string.Empty;

            // chuỗi tên không quá 30 ký tự, không được rỗng
            do
            {
                Console.Write("Nhập họ tên: ");
                tam = Console.ReadLine();
            } while (XuLyChuoiTen(tam).Length > 30);
            cauThu.hoTen = XuLyChuoiTen(tam);


            // ngày sinh trên 18 tuổi tính bằng năm hiện tại
            do
            {
                Console.Write("Nhập ngày sinh: ");
                cauThu.ngaySinh = DateTime.Parse(Console.ReadLine());
            } while (cauThu.ngaySinh.Year > 2004);

            // số áo kiểu số nguyên, không quá 2 chữ số
            do
            {
                Console.Write("Nhập số áo: ");
                cauThu.soAo = int.Parse(Console.ReadLine());
            } while (cauThu.soAo > 99);


            do
            {
                Console.Write("Nhập bàn thắng: ");
                cauThu.banThang = int.Parse(Console.ReadLine());
            } while (cauThu.banThang < 0);
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
    }
}
