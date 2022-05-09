using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @struct
{
    class BT1
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

            //a. nhập danh sách gồm n gói cước

            Console.Write("Nhập vào số lượng gói cước: ");
            int n = int.Parse(Console.ReadLine());

            // tạo mảng gồm n phần tử
            GoiCuoc[] arr = new GoiCuoc[n];

            // nhập mảng
            NhapMang(arr);

            // xuất mảng
            XuatMang(arr);
        }

        static void XuatMang(GoiCuoc[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                XuatGoi(arr[i]);
            }
        }

        static void XuatGoi(GoiCuoc x)
        {
            Console.WriteLine(x.tenGoi + "-" + x.chuKyGoi + "-" + x.giaGoi + "-" + x.vuotGoi);
        }

        static void NhapMang(GoiCuoc[] arr)
        {
            string tenGoi;
            int chuKyGoi;
            double giaGoi;
            int vuotGoi;

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("Nhập vào tên gói: ");
                tenGoi = Console.ReadLine();

                chuKyGoi = (tenGoi[tenGoi.Length - 1] - 48) * 30;

                Console.Write($"Nhập vào giá gói: ");
                giaGoi = double.Parse(Console.ReadLine());

                Console.Write($"Nhập vào vượt gói: ");
                vuotGoi = int.Parse(Console.ReadLine());

                arr[i] = new GoiCuoc(tenGoi, chuKyGoi, giaGoi, vuotGoi);
                Console.WriteLine();
            }
        }
    }
}
