using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*1. Tính tổng các phần tử trên mỗi cột
/*2. Tính tổng các phần tử trên mỗi hàng
 */
namespace HKII_KTLT2
{
    class BT0
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            int[,] arr;
            int hang = 0;
            int cot = 0;
            Console.Write("Nhập vào số lượng hàng: ");
            hang = int.Parse(Console.ReadLine());
            Console.Write("Nhập vào số lượng cột: ");
            cot = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Nhập vào mảng");
            arr = NhapMang(hang, cot);

            Console.WriteLine("Mảng vừa nhập");
            XuatMang2C(arr);
            Console.WriteLine();

            //1. Tính tổng các phần tử trên mỗi cột
            TongCacPhanTuTrenMoiCot(arr);
            Console.WriteLine();

            //2. Tính tổng các phần tử trên mỗi hàng
            TongCacPhanTuTrenMoiHang(arr);

        }

        static void TongCacPhanTuTrenMoiHang(int[,] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                sum = 0;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    sum += arr[i ,j];
                }
                Console.WriteLine($"Tổng các phần tử trên hàng {i}: {sum}");
            }
        }

        static void TongCacPhanTuTrenMoiCot(int[,] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                sum = 0;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    sum += arr[j ,i];
                }
                Console.WriteLine($"Tổng các phần tử trên cột {i}: {sum}");
            }
        }

        static void XuatMang2C(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static int[,] NhapMang(int hang, int cot)
        {
            int[,] arr = new int[hang, cot];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"Nhập Arr[{i}, {j}]: ");
                    arr[i, j] = int.Parse(Console.ReadLine());
                }
                Console.WriteLine();
            }
            return arr;
        }
    }
}
