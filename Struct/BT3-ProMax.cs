using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @struct
{
    class BT3_ProMax
    {
        struct GoiCuoc
        {
            public string tenGoi;
            public string tocDo;
            public double giaGoi;
            public double phiHoaMang;

            public GoiCuoc(string tenGoi, string tocDo, double giaGoi, double phiHoaMang)
            {
                this.tenGoi = tenGoi;
                this.tocDo = tocDo;
                this.giaGoi = giaGoi;
                this.phiHoaMang = phiHoaMang;
            }
        }
        struct ThueBao
        {
            public string hoTen;
            public string cmnd;
            public double quan;
            public GoiCuoc goiCuoc;

            public ThueBao(string hoTen, string cmnd, double quan, GoiCuoc goiCuoc)
            {
                this.hoTen = hoTen;
                this.cmnd = cmnd;
                this.quan = quan;
                this.goiCuoc = goiCuoc;
            }
        }
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            int n = 0;
            Console.Write("Nhập vào số lượng thuê bao: ");
            n = int.Parse(Console.ReadLine());

            ThueBao[] arr;
            arr = NhapMang(n);
            XuatMang(arr);
        }


        private static void XuatMang(ThueBao[] arr)
        {
            Console.WriteLine("-------------------");
            for (int i = 0; i < arr.Length; i++)
            {
                XuatThueBao(arr[i]);
            }
        }

        private static void XuatGoiCuoc(GoiCuoc goiCuoc)
        {
            Console.WriteLine("Tên gói: " + goiCuoc.tenGoi);
            Console.WriteLine("Tốc độ: " + goiCuoc.tocDo);
            Console.WriteLine("Giá gói: " + goiCuoc.giaGoi);
            Console.WriteLine("Phí hòa mạng: " + goiCuoc.phiHoaMang);
        }

        private static void XuatThueBao(ThueBao thueBao)
        {
            Console.WriteLine("Họ tên: " + thueBao.hoTen);
            Console.WriteLine("CMND: " + thueBao.cmnd);
            Console.WriteLine("Quận: " + thueBao.quan);
            Console.WriteLine("Tên gói: " + thueBao.goiCuoc.tenGoi);
            Console.WriteLine("Tốc độ: " + thueBao.goiCuoc.tocDo);
            Console.WriteLine("Giá gói: " + thueBao.goiCuoc.giaGoi);
            Console.WriteLine("Phí hòa mạng: " + thueBao.goiCuoc.phiHoaMang);

            Console.WriteLine();
        }

        private static ThueBao[] NhapMang(int n)
        {
            ThueBao[] arr = new ThueBao[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhập thuê bao thứ {i + 1}");
                NhapThueBao(out arr[i]);

                Console.WriteLine();
            }
            return arr;
        }

        // Nhập thuê bao
        private static void NhapThueBao(out ThueBao thueBao)
        {

            string tam = string.Empty;

            Console.Write("Nhập họ tên của thuê bao: ");
            tam = Console.ReadLine();

            thueBao.hoTen = XuLyChuoiHoTen(tam);

            do
            {
                Console.Write("Nhập CMND của thuê bao: ");
                tam = Console.ReadLine();
            } while (KiemTraCMND(tam) == false);
            thueBao.cmnd = tam;

            do
            {
                Console.Write("Nhập quận của thuê bao: ");
                thueBao.quan = double.Parse(Console.ReadLine());
            } while (thueBao.quan > 10);

            thueBao.goiCuoc = NhapGoiCuoc(thueBao.quan);

        }

        // Nhập gói cước
        private static GoiCuoc NhapGoiCuoc(double quan)
        {
            string tenGoi;
            string tocDo;
            double giaGoi;
            double phiHoaMang;


            do
            {
                Console.Write("Nhập tên gói: ");
                tenGoi = Console.ReadLine();
            } while (tenGoi.Length > 4);

            //5. Hàm tính tốc độ
            tocDo = TinhTocDo(tenGoi);

            do
            {
                Console.Write("Nhập giá gói: ");
                giaGoi = double.Parse(Console.ReadLine());
            } while (giaGoi < 99999);

            //4. Hàm tính phí hòa mạng
            phiHoaMang = TinhPhiHoaMang(quan);

            GoiCuoc gCuoc = new GoiCuoc(tenGoi, tocDo, giaGoi, phiHoaMang);
            return gCuoc;
        }

        private static string TinhTocDo(string tenGoi)
        {
            string tocDo;
            tocDo = tenGoi.Substring(0, 2);
            return tocDo;
        }

        // Hàm tính phí hòa mạng
        private static double TinhPhiHoaMang(double quan)
        {
            double phiHoaMang;

            if (quan == 1 || quan == 3 || quan == 5 || quan == 7)
            {
                phiHoaMang = 700000;
            }
            else
            {
                phiHoaMang = 0;
            }
            return phiHoaMang;
        }
        
        private static bool KiemTraCMND(string tam)
        {
            if (tam.Length != 9)
            {
                return false;
            }
            foreach (var item in tam)
            {
                if (item <= '0' || item > '9')
                {
                    return false;
                }
            }
            return true;
        }

        private static string XuLyChuoiHoTen(string tam)
        {
            tam = tam.Trim();
            tam = tam.ToLower();

            while (tam.Contains("  "))
            {
                tam = tam.Replace("  ", " ");
            }

            string[] arr = tam.Split(' ');
            string hoTenChuan = string.Empty;

            for (int i = 0; i < arr.Length; i++)
            {
                hoTenChuan += arr[i].Substring(0, 1).ToUpper() + arr[i].Substring(1) + " ";
            }

            hoTenChuan = hoTenChuan.TrimEnd();

            return hoTenChuan;
        }
    }
}
