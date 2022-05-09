using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @struct
{
    class BT2
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

        struct KhachHang
        {
            public string hoTen;
            public int cmnd;
            public GoiCuoc goiCuoc;

            public KhachHang(string hoTen, int cmnd, GoiCuoc goiCuoc)
            {
                this.hoTen = hoTen;
                this.cmnd = cmnd;
                this.goiCuoc = goiCuoc;
            }
        }
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Nhập vào số lượng: ");
            int n = int.Parse(Console.ReadLine());

            KhachHang[] arr = new KhachHang[n];

            NhapMang(arr);
            XuatMang(arr);
        }

        static void XuatMang(KhachHang[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"{arr[i].hoTen}-{arr[i].cmnd}-{arr[i].goiCuoc.tenGoi}-{arr[i].goiCuoc.chuKyGoi}-{arr[i].goiCuoc.giaGoi}-{arr[i].goiCuoc.vuotGoi}");
            }
        }
        static void NhapMang(KhachHang[] arr)
        {
           
            string tenGoi;
            int chuKyGoi;
            double giaGoi;
            int vuotGoi;
            string hoTenTam;

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Nhập người thứ {i}");
                Nhap:  Console.Write("Nhập họ tên: ");
                hoTenTam = Console.ReadLine();

                hoTenTam = hoTenTam.Trim();
                hoTenTam = hoTenTam.ToLower();
                while (hoTenTam.Contains("  "))
                {
                    Console.WriteLine("Họ tên không bao gồm các khoảng trắng giữa chuỗi");
                    Console.WriteLine("Vui lòng nhập lại");
                    goto Nhap;
                    hoTenTam.Replace("  ", " ");
                }

                string[] arrM = hoTenTam.Split(' ');

                for (int j = 0; j < arrM.Length; j++)
                {
                    arr[i].hoTen += arrM[j].Substring(0, 1).ToUpper() + arrM[j].Substring(1) + " ";
                }

                arr[i].hoTen = arr[i].hoTen.TrimEnd();

                Console.Write("Nhập CMND: ");
                arr[i].cmnd = int.Parse(Console.ReadLine());

                Console.Write("Nhập tên gói: ");
                tenGoi = Console.ReadLine();

                chuKyGoi = (tenGoi[tenGoi.Length - 1] - 48) * 30;

                Console.Write("Nhập giá gói: ");
                giaGoi = double.Parse(Console.ReadLine());

                Console.Write("Nhập vượt gói: ");
                vuotGoi = int.Parse(Console.ReadLine());

                Console.WriteLine();
                arr[i].goiCuoc = new GoiCuoc(tenGoi, chuKyGoi, giaGoi, vuotGoi);
            }
        }
    }
}
