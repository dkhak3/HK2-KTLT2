using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mang2ChieuOnTap
{
    class BT2X1
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            int dong = 0, cot = 0;

            int[,] arr;

            Console.Write("Nhập số lượng dòng: ");
            dong = SoLuong();

            Console.Write("Nhập số lượng cột: ");
            cot = SoLuong();

            arr = NhapChoNgoi(dong, cot);
            Console.WriteLine();

            XuatChoNgoi(arr);
            Console.WriteLine();

            //a) Tổng số chỗ ngồi còn trống trong rạp.
            Console.WriteLine($"Tổng số chổ ngồi còn trống trong rạp: {TongChoNgoiConTrong(arr)}");
            Console.WriteLine();


            //b) Số lượng ghế trống từng hàng.
            int[] soGheTrongHang = DemSoLuongGheTrongTungHang(arr);
            for (int i = 0; i < soGheTrongHang.Length; i++)
            {
                Console.WriteLine($"Số lượng ghế trống hàng {i}: {soGheTrongHang[i]}");
            }
            Console.WriteLine();


            //c) Số lượng ghế trống từng dãy.
            int[] soGheTrongDay = DemSoLuongGheTrongTungDay(arr);
            for (int i = 0; i < soGheTrongDay.Length; i++)
            {
                Console.WriteLine($"Số lượng ghế trống dãy {i}: {soGheTrongDay[i]}");
            }
            Console.WriteLine();


            //d) Số cặp ghế trống theo hàng
            int[] soCapGheTrongHang = DemSoLuongCapGheTrongTungHang(arr);
            for (int i = 0; i < soCapGheTrongHang.Length; i++)
            {
                Console.WriteLine($"Số lượng cặp ghế trống hàng {i}: {soCapGheTrongHang[i]}");
            }
            Console.WriteLine();


            //e) Tìm hàng có nhiều ghế trống nhất
            Console.WriteLine($"Hàng có nhiều ghế trống nhất: {TimHangNhieuGheTrongNhat(soGheTrongHang)}");
            Console.WriteLine();


            //f) tìm hàng đã hết chỗ trống
            int[] hangDaHetChoTrong = TimHangDaHetChoTrong(soGheTrongHang);
            for (int i = 0; i < hangDaHetChoTrong.Length; i++)
            {
                if (hangDaHetChoTrong[i] != 0)
                {
                    Console.WriteLine($"Hàng đã hết chỗ trống: {hangDaHetChoTrong[i]}");
                    break;
                }
                else
                {
                    Console.WriteLine("Không có hàng nào đã hết chỗ trống");
                    break;
                }
            }
            Console.WriteLine();


            //g) Kiểm tra tất cả các ghế ở ngoài biên được đặt hết hay chưa
            if (KiemTraGheTrongNgoaiBien(arr))
            {
                Console.WriteLine("Các ghế ngoài biên đã được đặt hết");
            }
            else
            {
                Console.WriteLine("Các ghế ngoài biên chưa được đặt hết");
            }
        }

        private static bool KiemTraGheTrongNgoaiBien(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                // hàng đầu chạy, cột không chạy
                if (arr[i, 0] == 0)
                {
                    return false;
                }
            }

            for (int i = 0; i < arr.GetLength(1); i++)
            {
                // cột đầu chạy, hàng không chạy
                if (arr[0, i] == 0)
                {
                    return false;
                }
            }

            for (int i = 1; i < arr.GetLength(0); i++)
            {
                // hàng cuối chạy, cột không chạy
                if (arr[i, arr.GetLength(1) - 1] == 0)
                {
                    return false;
                }
            }

            for (int i = 1; i < arr.GetLength(1); i++)
            {
                // cột cuối chạy, hàng không chạy
                if (arr[arr.GetLength(0) - 1, i] == 0)
                {
                    return false;
                }
            }

            return true;
        }

        private static int[] TimHangDaHetChoTrong(int[] arr)
        {
            int[] arrHangTrong = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                {
                    arrHangTrong[i] = i + 1;
                }
            }
            return arrHangTrong;
        }

        private static int TimHangNhieuGheTrongNhat(int[] arr)
        {
            int max = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (max < arr[i])
                {
                    max = arr[i];
                }
            }
            return max;
        }

        private static int[] DemSoLuongCapGheTrongTungHang(int[,] arr)
        {
            int[] arrM = new int[arr.GetLength(0)];

            int sum;
            int sumCap;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                sum = 0;
                sumCap = 0;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] == 0)
                    {
                        sum++;
                    }
                }
                if (sum == 2 || sum == 3)
                {
                    sumCap++;
                }
                if (sum == 4 || sum == 5)
                {
                    sumCap = 1;
                    sumCap++;
                }
                else if (sum == 6 || sum == 7)
                {
                    sumCap = 2;
                    sumCap++;
                }
                else if (sum == 8 || sum == 9)
                {
                    sumCap = 3;
                    sumCap++;
                }
                else if (sum == 10 || sum == 11)
                {
                    sumCap = 4;
                    sumCap++;
                }
                else if (sum == 12 || sum == 13)
                {
                    sumCap = 5;
                    sumCap++;
                }
                else if (sum == 14 || sum == 15)
                {
                    sumCap = 6;
                    sumCap++;
                }
                else if (sum == 16 || sum == 17)
                {
                    sumCap = 7;
                    sumCap++;
                }
                else if (sum == 18 || sum == 19)
                {
                    sumCap = 8;
                    sumCap++;
                }
                else if (sum == 20 || sum == 21)
                {
                    sumCap = 9;
                    sumCap++;
                }
                else if (sum == 22 || sum == 23)
                {
                    sumCap = 10;
                    sumCap++;
                }

                arrM[i] = sumCap;
            }
            return arrM;
        }

        private static int[] DemSoLuongGheTrongTungDay(int[,] arr)
        {
            int[] arrM = new int[arr.GetLength(1)];

            int sum;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                sum = 0;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[j, i] == 0)
                    {
                        sum++;
                    }
                }

                arrM[i] = sum;
            }
            return arrM;
        }

        private static int[] DemSoLuongGheTrongTungHang(int[,] arr)
        {
            int[] arrM = new int[arr.GetLength(0)];

            int sum;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                sum = 0;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] == 0)
                    {
                        sum++;
                    }
                }

                arrM[i] = sum;
            }
            return arrM;
        }

        private static int TongChoNgoiConTrong(int[,] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] != '1')
                    {
                        sum += arr[i, j];
                    }
                }
            }
            return sum;
        }

        private static void XuatChoNgoi(int[,] arr)
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

        private static int[,] NhapChoNgoi(int dong, int cot)
        {
            int[,] arr = new int[dong, cot];

            Random rand = new Random();

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rand.Next(0, 2);
                }
            }
            return arr;
        }

        private static int SoLuong()
        {
            int k = 0;
            do
            {
                k = int.Parse(Console.ReadLine());
            } while (k <= 0);
            return k;
        }
    }
}
