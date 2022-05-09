using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE1_CSC106055_05
{
    class Câu_1
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int d = 0, c = 0;
            int[,] arr;

            Console.Write("Nhập số lượng dòng: ");
            d = int.Parse(Console.ReadLine());

            Console.Write("Nhập số lượng cột: ");
            c = int.Parse(Console.ReadLine());

            //a. tạo mãng ngẫu nhiên (0 -> 100)
            arr = NhapMang(d, c);
            Console.WriteLine();

            //b. xuất mảng ngẫu nhiên (0 -> 100)
            XuatMang(arr);
            Console.WriteLine();

            //c. hàm tính trung bình cộng các phần tử từng cột
            double[] arrTBCot = TinhTrungBinhCongCot(arr);
            for (int i = 0; i < arrTBCot.Length; i++)
            {
                Console.WriteLine($"Trung bình cộng cột {i}: {Math.Round(arrTBCot[i], 3)}");
            }
            Console.WriteLine();

            //d. tìm phần tử lớn nhất từng dòng
            int[] maxDong = TimPhanTuLonNhatTungDong(arr);
            for (int i = 0; i < maxDong.Length; i++)
            {
                Console.WriteLine($"Phần tử lớn nhất dòng {i}: {maxDong[i]}");
            }
            Console.WriteLine();
        }

        static int[] TimPhanTuLonNhatTungDong(int[,] arr)
        {
            int[] arrMaxDong = new int[arr.GetLength(0)];

            int max = arr[0, 0];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                max = arr[i, 0];
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] > max)
                    {
                        max = arr[i, j];
                    }
                }
                arrMaxDong[i] = max;
            }
            return arrMaxDong;
        }

        static double[] TinhTrungBinhCongCot(int[,] arr)
        {
            double[] arrTBCot = new double[arr.GetLength(1)];

            double sum = 0;

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                sum = 0;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    sum += arr[j, i];
                }
                arrTBCot[i] = sum / arr.GetLength(0);
            }

            return arrTBCot;
        }

        static void XuatMang(int[,] arr)
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

        static int[,] NhapMang(int d, int c)
        {
            Random rand = new Random();

            int[,] arr = new int[d, c];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rand.Next(0, 101);
                }
            }
            return arr;
        }
    }
}
