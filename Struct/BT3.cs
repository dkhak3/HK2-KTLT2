using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @struct
{
    class BT3
    {
        struct GoiCuocTV
        {
            public string tenGoi;
            public string tocDo;
            public double giaGoi;
            public double phiHoaMang;

            public GoiCuocTV(string tenGoi, string tocDo, double giaGoi, double phiHoaMang)
            {
                this.tenGoi = tenGoi;
                this.tocDo = tocDo;
                this.giaGoi = giaGoi;
                this.phiHoaMang = phiHoaMang;
            }
        }

        struct ThueBaoTV
        {
            public string hoTen;
            public int cmnd;
            public int quan;
            public GoiCuocTV goiCuocTV;

            public ThueBaoTV(string hoTen, int cmnd, int quan, GoiCuocTV goiCuocTV)
            {
                this.hoTen = hoTen;
                this.cmnd = cmnd;
                this.quan = quan;
                this.goiCuocTV = goiCuocTV;
            }
        }
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Nhập vào số lượng: ");
            int n = int.Parse(Console.ReadLine());

            ThueBaoTV[] arr = new ThueBaoTV[n];

            NhapMang(arr);
            Console.WriteLine("-------------------------");
            XuatMang(arr);
        }

        static void XuatMang(ThueBaoTV[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Xuất người thứ {i}");
                Console.WriteLine("Họ tên: " + arr[i].hoTen);
                Console.WriteLine("CMND: " + arr[i].cmnd);
                Console.WriteLine("Quận: " + arr[i].quan);
                Console.WriteLine("Tên gói: " + arr[i].goiCuocTV.tenGoi);
                Console.WriteLine("Tốc độ: " + arr[i].goiCuocTV.tocDo);
                Console.WriteLine("Giá gói: " + arr[i].goiCuocTV.giaGoi);
                Console.WriteLine("Phí hòa mạng: " + arr[i].goiCuocTV.phiHoaMang);

                Console.WriteLine();
            }
        }

        static void NhapMang(ThueBaoTV[] arr)
        {
            string tenGoi;
            string tocDo;
            double giaGoi;
            double phiHoaMang;

            string hoTenTam;
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Nhập người thứ {i}");

                Nhap: Console.Write("Nhập họ tên: ");
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

                Console.Write("Nhập quận: ");
                arr[i].quan = int.Parse(Console.ReadLine());

                Console.Write("Nhập tên gói: ");
                tenGoi = Console.ReadLine();

                tocDo = tenGoi.Substring(0, 2);

                Console.Write("Nhập giá gói: ");
                giaGoi = double.Parse(Console.ReadLine());


                if (arr[i].quan == 1 || arr[i].quan == 3 || arr[i].quan == 5 || arr[i].quan == 7)
                {
                    phiHoaMang = 70000;
                }
                else
                {
                    phiHoaMang = 0;
                }

                Console.WriteLine();
                arr[i].goiCuocTV = new GoiCuocTV(tenGoi, tocDo, giaGoi, phiHoaMang);
            }
        }
    }
}
