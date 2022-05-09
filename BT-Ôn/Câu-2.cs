using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BT_Ôn
{
    class Câu_2
    {
        struct NhanVien
        {
            public string hoTen;
            public DateTime ngaySinh;
            public DiaChi diaChi;

            public NhanVien(string hoTen, DateTime ngaySinh, DiaChi diaChi)
            {
                this.hoTen = hoTen;
                this.ngaySinh = ngaySinh;
                this.diaChi = diaChi;
            }

        }
        struct DiaChi
        {
            public string soNha;
            public string quan;

            public DiaChi(string soNha, string quan)
            {
                this.soNha = soNha;
                this.quan = quan;
            }
        }
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            int n = 0;
            NhanVien[] arr;

            arr = NhapMang(n);

            XuatMang(arr);

            GhiFileTimNhanVien(arr);
        }

        private static void GhiFileTimNhanVien(NhanVien[] arr)
        {
            Console.Write("Nhập vào quận cần tìm nhân viên: ");
            string timQuan = Console.ReadLine();
            try
            {
                StreamWriter ghiFile = new StreamWriter(@"D:\NguyenHuuDuyKha_Output.TXT");
                using (ghiFile)
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (timQuan == arr[i].diaChi.quan)
                        {
                            ghiFile.WriteLine($"{arr[i].hoTen}#{arr[i].ngaySinh.ToString("dd/mm/yyyy")}#{arr[i].diaChi.soNha}#{arr[i].diaChi.quan}");
                        }
                    }
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Không tìm thấy file");
            }
        }

        private static void XuatMang(NhanVien[] arr)
        {
            Console.WriteLine("-----------------");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Xuất nhân viên thứ {i + 1}");

                XuatNhanVien(arr[i]);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static void XuatNhanVien(NhanVien nhanVien)
        {
            Console.WriteLine("Họ tên: " + nhanVien.hoTen);
            Console.WriteLine("Ngày sinh: " + nhanVien.ngaySinh.ToString("dd/mm/yyyy"));
            Console.WriteLine("Số nhà: " + nhanVien.diaChi.soNha);
            Console.WriteLine("Quận: " + nhanVien.diaChi.quan);
        }

        private static NhanVien[] NhapMang(int n)
        {
            Console.Write("Nhập số lượng nhân viên: ");
            n = int.Parse(Console.ReadLine());

            NhanVien[] arr = new NhanVien[n];
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Nhập nhân viên thứ {i + 1}");
                NhapNhanVien(out arr[i]);

                Console.WriteLine();
            }
            return arr;
        }

        private static void NhapNhanVien(out NhanVien nhanVien)
        {
            string tam = string.Empty;

            do
            {
                Console.Write("Nhập họ tên: ");
                tam = Console.ReadLine();
            } while (XuLyChuoiTen(tam).Length > 30);
            nhanVien.hoTen = XuLyChuoiTen(tam);

            do
            {
                Console.Write("Nhập ngày sinh: ");
                nhanVien.ngaySinh = DateTime.Parse(Console.ReadLine());
            } while (nhanVien.ngaySinh.Year > 2002);

            nhanVien.diaChi = NhapDiaChi();
        }

        private static DiaChi NhapDiaChi()
        {
            string soNha;
            string quan;

            Console.Write("Nhập số nhà: ");
            soNha = Console.ReadLine();

            Console.Write("Nhập quận: ");
            quan = Console.ReadLine();

            DiaChi dChi = new DiaChi(soNha, quan);

            return dChi;
        }

        private static string XuLyChuoiTen(string tam)
        {
            tam = tam.ToLower();
            tam = tam.Trim();

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
