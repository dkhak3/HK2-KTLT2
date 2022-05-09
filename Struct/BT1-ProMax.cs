using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @struct
{
    class BT1_Pro
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
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            int n = 0;
            Console.Write("Nhập vào số lượng gói cước: ");
            n = int.Parse(Console.ReadLine());

            GoiCuoc[] arr;

            arr = NhapMang(n);
            XuatMang(arr);
        }

        private static void XuatMang(GoiCuoc[] arr)
        {
            Console.WriteLine("--------------------------");
            for (int i = 0; i < arr.Length; i++)
            {
                XuatThongTinGoi(arr[i]);
            }
        }

        private static void XuatThongTinGoi(GoiCuoc goiCuoc)
        {
            Console.WriteLine($"{goiCuoc.tenGoi} - {goiCuoc.chuKyGoi} - {goiCuoc.giaGoi} - {goiCuoc.vuotGoi}");
        }

        private static GoiCuoc[] NhapMang(int n)
        {
            GoiCuoc[] arr = new GoiCuoc[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhập gói cước thứ {i}");
                NhapGoiCuoc(out arr[i]);
                Console.WriteLine();
            }
            return arr;
        }

        private static void NhapGoiCuoc(out GoiCuoc goiCuoc)
        {
            do
            {
                Console.Write("Nhập tên gói: ");
                goiCuoc.tenGoi = Console.ReadLine();
            } while (goiCuoc.tenGoi.Length > 10);

            goiCuoc.chuKyGoi = (goiCuoc.tenGoi[goiCuoc.tenGoi.Length - 1] - 48) * 30;

            do
            {
                Console.Write("Nhập giá gói: ");
                goiCuoc.giaGoi = double.Parse(Console.ReadLine());
            } while (goiCuoc.giaGoi < 999999);

            Console.Write("Nhập vượt gói: ");
            goiCuoc.vuotGoi = int.Parse(Console.ReadLine());

        }
    }
}
