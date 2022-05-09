using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE3
{
    class NguyenHuuDuyKha_Cau1
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            int n = 0;

            int[,] arr;

            arr = NhapMaTranVuong(n);

            XuatMaTranVuong(arr);
            Console.WriteLine();


            // tính TBC các phần tử từng cột
            double[] arrTBCCot = TinhTBCCacPhanTuTungCot(arr);
            for (int i = 0; i < arrTBCCot.Length; i++)
            {
                Console.WriteLine($"Trung bình cộng các phần tử cột {i + 1}: {arrTBCCot[i]}");
            }
            Console.WriteLine();


            // tính tích các phần tử tạo các biên của ma trận
            Console.WriteLine($"Tích các phần tử tại các biên của ma trận: {TinhTichCacPhanTuTaiCacBien(arr)}");
            Console.WriteLine();


            // tính tổng các phần tử ở vị trí tam giác trên so với đường chéo chính
            Console.WriteLine($"Tổng các phần tử ở vị trí tam giác trên so với đường chéo chính {TongCacPhanTuOTamGiacTren(arr)}");
        }

        private static double TongCacPhanTuOTamGiacTren(int[,] arr)
        {
            int sum = 0;
            int dem = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (j >= i)
                    {
                        sum += arr[i, j];
                        dem++;
                    }
                }
            }
            return dem / (double)sum;
        }

        private static long TinhTichCacPhanTuTaiCacBien(int[,] arr)
        {
            long tich = 1;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (j == 0 || j == arr.GetLength(0) - 1 || i == 0 || i == arr.GetLength(0) - 1)
                    {
                        tich *= arr[i, j];
                    }
                }
            }
            return tich;
        }

        private static double[] TinhTBCCacPhanTuTungCot(int[,] arr)
        {
            double[] TBCCot = new double[arr.GetLength(1)];
            double sum;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                sum = 0;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    sum += arr[j, i];
                }
                TBCCot[i] = sum / arr.GetLength(0) * arr.GetLength(1);
            }
            return TBCCot;
        }

        private static void XuatMaTranVuong(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + "   ");
                }
                Console.WriteLine();
            }
        }

        private static int[,] NhapMaTranVuong(int n)
        {
            Console.Write("Nhập kích thước ma trận vuông: ");
            n = int.Parse(Console.ReadLine());
            Random rand = new Random();

            int[,] arr = new int[n, n];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rand.Next(0, 100);
                }
            }
            return arr;
        }
    }
}
