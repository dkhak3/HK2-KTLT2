using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//2.Viết đoạn chương trình thống kê số chỗ ngồi còn trống trong câu 1 như sau:
//a) Tổng số chỗ ngồi còn trống trong rạp.
//b) Số lượng ghế trống từng hàng.
//c) Số lượng ghế trống từng dãy.
//d) Số cặp ghế trống theo hàng
//e) Tìm hàng có nhiều ghế trống nhất
//f) Tìm hàng đã hết chỗ trống 
//g) Kiểm tra tất cả các ghế ở ngoài biên được đặt hết hay chưa.
namespace BAI_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int hang = 0;
            int cot = 0;
            int[,] arr;
            int dem = 0;
            Console.WriteLine("Nhập vào số hàng:");
            hang = SoLuong();
            Console.WriteLine("Nhập vào số cột:");
            cot = SoLuong();
            arr = GheRap(hang, cot);
            XuatHangGhe(arr);
            Console.WriteLine();

            //a. Tổng số chỗ ngồi còn trống trong rạp.
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                dem += DemGheTrong(arr, i, 1);
            }
            Console.WriteLine($"Số ghế trống của rạp là: {dem}");
            dem = 0;
            Console.WriteLine();

            //b.  Số lượng ghế trống từng hàng.
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                dem++;
                Console.WriteLine($"Số ghế trống của hàng {dem}: {DemGheTrong(arr, i, 1)}");
            }
            dem = 0;
            Console.WriteLine();

            //c. Số lượng ghế trống từng dãy.
            for (int i = 0; i < arr.GetLength(1); i++)
            {
                dem++;
                Console.WriteLine($"Số ghế trống của dãy {dem}: {DemGheTrong(arr, i, 0)}");
            }
            dem = 0;
            Console.WriteLine();

            //d. Số cặp ghế trống theo hàng
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                dem++;
                Console.WriteLine($"Số cặp ghế hàng {dem}: {DemCapGheTrong(arr, i)}");
            }
            dem = 0;
            Console.WriteLine();

            //e. Tìm hàng có nhiều ghế trống nhất
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                dem++;
                if (SoGheTrongLongNhatCua1Hang(arr) == DemGheTrong(arr, i, 1))
                {
                    Console.WriteLine($"Hàng ghế trống nhiều nhất là: {dem}");
                }
            }
            dem = 0;
            Console.WriteLine();

            //f. Tìm hàng đã hết chỗ trống
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                dem++;
                if (DemGheTrong(arr, i, 1) == 0)
                {
                    Console.WriteLine($"Hàng ghế hết chỗ trống: {dem}");
                }
            }
            dem = 0;
            Console.WriteLine();

            //g. Kiểm tra tất cả các ghế ở ngoài biên được đặt hết hay chưa.
            if (KiemTraGheBien(arr) == true)
            {
                Console.WriteLine("Các ghế ngoài biên đã được đặt hết.");
            }
            else
            {
                Console.WriteLine("Các ghế ngoài biên chưa được đặt hết.");
            }
        }
        static bool KiemTraGheBien(int[,] arr)
        {
            if (DemGheTrong(arr, 0, 1) != 0 || DemGheTrong(arr, 0, 0) != 0 ||
                DemGheTrong(arr, arr.GetLength(1) - 1, 0) != 0
                || DemGheTrong(arr, arr.GetLength(0) - 1, 1) != 0)
            {
                return false;
            }
            return true;
        }
        static int SoGheTrongLongNhatCua1Hang(int[,] arr)
        {
            int max = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                if (max < DemGheTrong(arr, i, 1))
                {
                    max = DemGheTrong(arr, i, 1);
                }
            }
            return max;
        }
        static int DemCapGheTrong(int[,] arr, int i)
        {
            int dem = 0;
            int j = 0;
            int k = 1;
            do
            {
                if (arr[i, j] == 0 && arr[i, k] == 0)
                {
                    dem++;
                    j = k + 1;
                    k = k + 2;
                }
                else
                {
                    j++;
                    k++;
                }
            } while (k < arr.GetLength(1));
            return dem;
        }
        static int DemGheTrong(int[,] arr, int i, int k)
        {
            int dem = 0;
            if (k == 1)
            {
                for (int j = 0; j < arr.GetLength(k); j++)
                {
                    if (arr[i, j] == 0)
                    {
                        dem++;
                    }
                }
            }
            else
            {
                for (int j = 0; j < arr.GetLength(k); j++)
                {
                    if (arr[j, i] == 0)
                    {
                        dem++;
                    }
                }
            }
            return dem;
        }
        static void XuatHangGhe(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"{arr[i, j]}  ");
                }
                Console.WriteLine();
            }
        }
        static int[,] GheRap(int hang, int cot)
        {
            int[,] arr = new int[hang, cot];
            Random r = new Random();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = r.Next(2);
                }
            }
            return arr;
        }
        static int SoLuong()
        {
            int n = 0;
            do
            {
                n = int.Parse(Console.ReadLine());
            } while (n <= 0);
            return n;
        }
    }
}