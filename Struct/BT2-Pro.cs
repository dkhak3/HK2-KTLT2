using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @struct
{
    class BT2_Quality
    {
        struct GoiCuoc
        {
            public string tenGoi;
            public int chuKyGoi;
            public double giaGoi;
            public int vuotGoi;

            public GoiCuoc(string tenGoi, int chuKyGoi, double giaGoi, int vuotGoi)
            {
                this.tenGoi = tenGoi;
                this.chuKyGoi = chuKyGoi;
                this.giaGoi = giaGoi;
                this.vuotGoi = vuotGoi;
            }
        }

        struct ThueBao
        {
            public string hoTen;
            public string cmnd;
            public GoiCuoc goiCuoc;

            public ThueBao(string hoTen, string cmnd, GoiCuoc goiCuoc)
            {
                this.hoTen = hoTen;
                this.cmnd = cmnd;
                this.goiCuoc = goiCuoc;
            }
        }
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            
            ThueBao tB = NhapThongTinThueBao();
            Console.WriteLine();

            Console.WriteLine(XuatThueBao(tB));
        }

        private static string XuatThueBao(ThueBao tB)
        {
            string s = $"{tB.hoTen} - {tB.cmnd} - {tB.goiCuoc.tenGoi} - {tB.goiCuoc.chuKyGoi} - {tB.goiCuoc.giaGoi} - {tB.goiCuoc.vuotGoi}";
            return s;
        }

        private static ThueBao NhapThongTinThueBao()
        {
            int n = 0;
            string tam = string.Empty;

            ThueBao tB = new ThueBao();

            Console.Write("Nhập họ tên: ");
            tam = Console.ReadLine();

            tB.hoTen = XuLyChuoiTen(tam);

            do
            {
                Console.Write("Nhập CMND của thuê bao: ");
                tam = Console.ReadLine();
            } while (KiemTraCMND(tam) == false);
            tB.cmnd = tam;

            tB.goiCuoc = NhapThongTinGoiCuoc();

            return tB;
        }

        private static GoiCuoc NhapThongTinGoiCuoc()
        {
            string tenGoi;
            int chuKyGoi;
            double giaGoi;
            int vuotGoi;

            do
            {
                Console.Write("Nhập tên gói: ");
                tenGoi = Console.ReadLine();
            } while (tenGoi.Length <= 0 || tenGoi.Length > 10);

            chuKyGoi = (tenGoi[tenGoi.Length - 1] - 43) * 30;

            do
            {
                Console.Write("Nhập giá gói: ");
                giaGoi = double.Parse(Console.ReadLine());
            } while (giaGoi < 99999);

            Console.Write("Nhập vượt gói: ");
            vuotGoi = int.Parse(Console.ReadLine());

            GoiCuoc gCuoc = new GoiCuoc(tenGoi, chuKyGoi, giaGoi, vuotGoi);
            return gCuoc;
        }

        private static bool KiemTraCMND(string soCMND)
        {
            if (soCMND.Length != 9)
            {
                return false;
            }
            foreach (var item in soCMND)
            {
                if (item <= '0' || item > '9')
                {
                    return false;
                }
            }
            return true;
        }

        static string XuLyChuoiTen(string tam)
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
