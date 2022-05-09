using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mang2ChieuOnTap
{
    class BT7X1
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            int m = 0, n = 0;

            Console.Write("Nhập số lượng hàng: ");
            m = int.Parse(Console.ReadLine());

            Console.Write("Nhập số lượng cột: ");
            n = int.Parse(Console.ReadLine());

            int[,] arrChuNhat;

            // Nhập mảng ma trận vuông
            arrChuNhat = NhapMaTranChuNhat(m, n);
            Console.WriteLine();


            // Xuất ma trận ma trận hình chữ nhật
            XuatMaTran(arrChuNhat);


            // Tạo ma trận vuông từ ma trận hình chữ nhật
            int[,] arrVuong;

            if (arrChuNhat.GetLength(0) < arrChuNhat.GetLength(1))
            {
                arrVuong = new int[arrChuNhat.GetLength(0), arrChuNhat.GetLength(1)];
            }
            else
            {
                arrVuong = new int[arrChuNhat.GetLength(1), arrChuNhat.GetLength(1)];
            }
            Console.WriteLine();


            // Nhập mảng ma trận vuông từ ma trận hình chữ nhật
            KhoiTaoMaTranVuong(arrChuNhat, arrVuong);

            // Xuất ma trận vuông
            Console.WriteLine("Ma trận vuông sau khi được khởi tạo từ ma trận chữ nhật");
            XuatMaTran(arrVuong);
            Console.WriteLine();


            //a. Viết hàm tính tích các phần tử trên mỗi cột của ma trận
            int[] arrTichMoiCot = TinhTichCacPhanTuMoiCot(arrVuong);
            for (int i = 0; i < arrTichMoiCot.Length; i++)
            {
                Console.WriteLine($"Tích phần tử cột {i}: {arrTichMoiCot[i]}");
            }
            Console.WriteLine();


            //b. Viết hàm tính tích các phần tử nằm trên đường chéo chính, chéo phụ của ma trận
            //vuông
            Console.WriteLine($"Tích các phần tử nằm trên đường chéo chính: {TinhTichCacPhanTuTrenDuongCheoChinh(arrVuong)}");
            Console.WriteLine();

            Console.WriteLine($"Tích các phần tử nằm trên đường chéo phụ: {TinhTichCacPhanTuTrenDuongCheoPhu(arrVuong)}");
            Console.WriteLine();


            //c. Viết hàm tính tổng các phần tử là số nguyên tố có trong ma trận.
            Console.WriteLine($"Tổng các phần tử là số nguyên tố: {TongCacPhanTuSoNguyenTo(arrVuong)}");
            Console.WriteLine();


            //d. Viết hàm tính giá trị trung bình của các phần tử là số chẵn trong ma trận
            Console.WriteLine($"Giá trị trung bình các phần tử chẵn: {TichTrungBinhChan(arrVuong)}");
            Console.WriteLine();


            //e. Viết hàm tìm phần tử lẻ lớn nhất trong ma trận
            Console.WriteLine($"Phần tử lẻ lớn nhất: {TimPhanTuLeLonNhat(arrVuong)}");
            Console.WriteLine();


            //f. Viết hàm đếm số lần xuất hiện của phần tử x trong ma trận, với x được nhập từ
            //bàn phím.
            int x = 0;
            Console.Write("Nhập số cần đếm số lần xuất hiện trong ma trận: ");
            x = int.Parse(Console.ReadLine());
            Console.WriteLine($"Số lần xuất hiện của {x} trong ma trận: {DemSoLanXXuatHien(arrVuong, x)}");
            Console.WriteLine();


            //g. Viết hàm sắp xếp ma trận theo thứ tự tăng dần từ trên xuống dưới và từ trái qua
            //phải theo phương pháp dùng mảng phụ.
            Console.WriteLine("Mảng Viết sau sắp xếp theo thứ tự tăng dần từ trên xuống dưới và từ trái qua phải");
            SapXepMaTranTangDanTheoCotVaDong(arrVuong);
            XuatMaTran(arrVuong);

        }

        private static void SapXepMaTranTangDanTheoCotVaDong(int[,] arrVuong)
        {
            int[] arr = new int[arrVuong.GetLength(0) * arrVuong.GetLength(1)];
            int k = 0;
            for (int i = 0; i < arrVuong.GetLength(0); i++)
            {
                for (int j = 0; j < arrVuong.GetLength(1); j++)
                {
                    arr[k++] = arrVuong[i, j];
                }
            }

            SapXepMang1ChieuTangDan(arr);

            k = 0;
            for (int i = 0; i < arrVuong.GetLength(0); i++)
            {
                for (int j = 0; j < arrVuong.GetLength(1); j++)
                {
                    arrVuong[i, j] = arr[k++];
                }
            }
        }

        static void SapXepMang1ChieuTangDan(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = arr.Length - 1; j > i; j--)
                {
                    if (arr[j] < arr[j - 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = temp;
                    }
                }
            }
        }

        private static int DemSoLanXXuatHien(int[,] arrVuong, int x)
        {
            int dem = 0;
            for (int i = 0; i < arrVuong.GetLength(0); i++)
            {
                for (int j = 0; j < arrVuong.GetLength(1); j++)
                {
                    if (x == arrVuong[i, j])
                    {
                        dem++;
                    }
                }
            }
            return dem;
        }

        private static int TimPhanTuLeLonNhat(int[,] arrVuong)
        {
            int max = arrVuong[0, 0];
            for (int i = 0; i < arrVuong.GetLength(0); i++)
            {
                for (int j = 0; j < arrVuong.GetLength(1); j++)
                {
                    if (arrVuong[i, j] % 2 != 0)
                    {
                        if (arrVuong[i,j] > max)
                        {
                            max = arrVuong[i, j];
                        }
                    }
                }
            }
            return max;
        }

        private static double TichTrungBinhChan(int[,] arrVuong)
        {
            double sum = 0;
            for (int i = 0; i < arrVuong.GetLength(0); i++)
            {
                for (int j = 0; j < arrVuong.GetLength(1); j++)
                {
                    if (arrVuong[i, j] % 2 == 0)
                    {
                        sum += arrVuong[i, j];
                    }
                }
            }

            return sum / arrVuong.GetLength(0) * arrVuong.GetLength(1);
        }

        private static int TongCacPhanTuSoNguyenTo(int[,] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (CheckSoNguyenTo(arr[i, j]) == true)
                    {
                        sum += arr[i, j];
                    }
                }
            }
            return sum;
        }

        static bool CheckSoNguyenTo(int n)
        {
            if (n < 2)
            {
                return false;
            }
            for (int i = 2; i <= n/2 ; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private static int TinhTichCacPhanTuTrenDuongCheoPhu(int[,] arrVuong)
        {
            int sum = 0;
            int soDong = arrVuong.GetLength(0);
            for (int i = 0; i < arrVuong.GetLength(1); i++)
            {
                soDong = soDong - 1;
                for (int j = 0; j < arrVuong.GetLength(1); j++)
                {
                    sum += arrVuong[i, j];
                }
            }

            return sum;
        }

        private static int TinhTichCacPhanTuTrenDuongCheoChinh(int[,] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        sum += arr[i, j];
                    }
                }
            }
            return sum;
        }

        private static int[] TinhTichCacPhanTuMoiCot(int[,] arr)
        {
            int[] tichMoiCuot = new int[arr.GetLength(1)];
            int tich = 0;

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                tich = 1;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    tich = tich * arr[j, i];
                }
                tichMoiCuot[i] = tich;
            }
            return tichMoiCuot;
        }

        private static void KhoiTaoMaTranVuong(int[,] arrChuNhat, int[,] arrVuong)
        {
            for (int i = 0; i < arrVuong.GetLength(0); i++)
            {
                for (int j = 0; j < arrVuong.GetLength(1); j++)
                {
                    arrVuong[i, j] = arrChuNhat[i, j];
                }
            }
        }

        private static void XuatMaTran(int[,] arr)
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

        private static int[,] NhapMaTranChuNhat(int m, int n)
        {
            int[,] arr = new int[m, n];
            Random rand = new Random();

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = rand.Next(0, 10);
                }
            }
            return arr;
        }
    }
}
