using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EXE2
{
    class NguyenHuuDuyKha_CD21TT4
    {
        struct ThongTinPhim
        {
            public string tenPhim;
            public DateTime ngayPhatHanh;
            public int soTap;
            public ThongTinCongTy thongTinCongTy;

            public ThongTinPhim(string tenPhim, DateTime ngayPhatHanh, int soTap, ThongTinCongTy thongTinCongTy)
            {
                this.tenPhim = tenPhim;
                this.ngayPhatHanh = ngayPhatHanh;
                this.soTap = soTap;
                this.thongTinCongTy = thongTinCongTy;
            }

        }

        struct ThongTinCongTy
        {
            public string tenCongTy;
            public string diaChi;

            public ThongTinCongTy(string tenCongTy, string diaChi)
            {
                this.tenCongTy = tenCongTy;
                this.diaChi = diaChi;
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            int n = 0;
            ThongTinPhim[] arr;

            Console.Write("Nhập số lượng thông tin: ");
            n = int.Parse(Console.ReadLine());        

            // Nhập các thông tin
            arr = NhapMang(n);

            // Xuất các thông tin ra màng hình
            XuatMang(arr);

            // Xuất thông tin vô file HoTenSV_Output_De3.txt
            GhiFile(arr);
        }

        private static void GhiFile(ThongTinPhim[] a)
        {
            try
            {
                
                using (StreamWriter ghiFile = new StreamWriter("NguyenHuuDuyKha_Output_De3.txt"))
                {
                    for (int i = 0; i < a.Length; i++)
                    {
                        ghiFile.WriteLine($"{a[i].tenPhim}#{a[i].ngayPhatHanh.ToString("d/M/yyyy")}#{a[i].soTap}##{a[i].thongTinCongTy.tenCongTy}#{a[i].thongTinCongTy.diaChi}");
                    }
                }
            }
            catch (IOException)
            {

                Console.WriteLine("Không tìm thấy file");
            }
        }

        private static void XuatMang(ThongTinPhim[] arr)
        {
            Console.WriteLine("------------------");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Xuất thông tin thứ {i + 1}");
                XuatThongTin(arr[i]);

                Console.WriteLine();
            }
        }

        private static void XuatThongTin(ThongTinPhim thongTinPhim)
        {
            Console.WriteLine("Tên phim: " + thongTinPhim.tenPhim);
            Console.WriteLine("Ngày phát hành: " + thongTinPhim.ngayPhatHanh.ToString("d/M/yyyy"));
            Console.WriteLine("Số tập: " + thongTinPhim.soTap);
            Console.WriteLine("Tên công ty: " + thongTinPhim.thongTinCongTy.tenCongTy);
            Console.WriteLine("Địa chỉ: " + thongTinPhim.thongTinCongTy.diaChi);
        }

        private static ThongTinPhim[] NhapMang(int n)
        {
            ThongTinPhim[] arr = new ThongTinPhim[n];

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Nhập thông tin thứ {i + 1}");
                NhapThongTinPhim(out arr[i]);

                Console.WriteLine();
            }
            return arr;
        }

        private static void NhapThongTinPhim(out ThongTinPhim thongTinPhim)
        {
            Console.Write("Nhập tên phim: ");
            thongTinPhim.tenPhim = Console.ReadLine();

            // Ngày phát hành không được lớn hơn ngày hiện hành
            do
            {
                Console.Write("Nhập ngày phát hành: ");
                thongTinPhim.ngayPhatHanh = DateTime.Parse(Console.ReadLine());
            } while (KiemTraNgayPhatHanh(thongTinPhim.ngayPhatHanh) == false);

            // Số tập không quá 2 chữ số
            do
            {
                Console.Write("Nhập số tập: ");
                thongTinPhim.soTap = int.Parse(Console.ReadLine());
            } while (thongTinPhim.soTap > 99);

            thongTinPhim.thongTinCongTy = NhapThongTinCongTy();
        }

        private static ThongTinCongTy NhapThongTinCongTy()
        {
            string tenCongTy;
            string diaChi;

            Console.Write("Nhập tên công ty: ");
            tenCongTy = Console.ReadLine();

            Console.Write("Nhập địa chỉ: ");
            diaChi = Console.ReadLine();

            ThongTinCongTy thongTin = new ThongTinCongTy(tenCongTy, diaChi);
            return thongTin;
        }

        private static bool KiemTraNgayPhatHanh(DateTime ngayPhatHanh)
        {
            DateTime ngayHienTai = DateTime.Now;
            if (ngayPhatHanh < ngayHienTai)
            {
                return true;
            }
            return false;
        }
    }
}
