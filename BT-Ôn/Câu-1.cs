using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_Ôn
{
    class Cau_1
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            int n = 0;
            int[,] arr;


            // nhập ma trân ngẫu nhiên ( 1 > 100 ) với kích thước n
            arr = NhapMaTranNgauNhien(n);


            // xuất ma trận ngẫu nhiên
            XuatMaTranNgauNhien(arr);


            // tìm giá trị lớn nhất từng cột
            int[] maxCot = TimGiaTriLonNhatTrungCot(arr);
            for (int i = 0; i < maxCot.Length; i++)
            {
                Console.WriteLine($"Giá trị lớn nhất cột thứ {i + 1}: {maxCot[i]}");
            }
        }

        private static int[] TimGiaTriLonNhatTrungCot(int[,] arr)
        {
            int[] maxCot = new int[arr.GetLength(1)];
            int max;

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                max = arr[0, 0];
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (max < arr[i, j])
                    {
                        max = arr[i, j];
                    }
                }
                maxCot[i] = max;
            }
            return maxCot;
        }

        private static void XuatMaTranNgauNhien(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + "  ");
                }
                Console.WriteLine();
            }
        }

        private static int[,] NhapMaTranNgauNhien(int n)
        {
            Console.Write($"Nhập kích thước ma trận: ");
            n = int.Parse(Console.ReadLine());
            Random rand = new Random();

            int[,] arr = new int[n, n];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rand.Next(1, 100);
                }
            }
            return arr; 
        }
    }
}
