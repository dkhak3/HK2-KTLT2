using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKII_KTLT2
{
    class BT7
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            int[,] arr;
            int m = 0, n = 0, x = 0;
            int[,] arr1;

            Console.Write("Nhập vào chiều dài n: ");
            n = int.Parse(Console.ReadLine());

            Console.Write("Nhập vào chiều dài m: ");
            m = int.Parse(Console.ReadLine());

            Console.WriteLine("Ma trận hình nhữ nhật: ");
            arr = NhapMaTran(m, n);
            XuatMaTran(arr);

            Console.WriteLine("Ma trận hình vuông có các cạnh hình nhữ nhật nhỏ nhất: ");
            if (m < n)
            {
                arr1 = Coppy(arr, m);
            }
            else
            {
                arr1 = Coppy(arr, n);
            }
            XuatMaTran(arr1);

            //a. Viết hàm tính tích các phần tử trên mỗi cột của ma trận
            TinhPhanTuCuaCot(arr1);

            //b. Viết hàm tính tích các phần tử nằm trên đường chéo chính, chéo phụ của ma trận
            //vuông.
            Console.WriteLine($"Tích đường chéo chính: {TinhTichPhanTuCheoChinh(arr1)}");

            Console.WriteLine($"Tích đường chéo phụ: {TinhTichPhanTuCheoPhu(arr1)}");
            Console.WriteLine();

            //c. Viết hàm tính tổng các phần tử là số nguyên tố có trong ma trận.
            Console.WriteLine($"Tổng các phần tử là số nguyên tố: {TongPhanTuSoNguyenTo(arr1)}");
            Console.WriteLine();

            //d. Viết hàm tính giá trị trung bình của các phần tử là số chẵn trong ma trận.
            Console.WriteLine($"Giá trị trung bình của các phần tử chẵn: {TrungBinhCacPhanTuChan(arr1)}");

            //e. Viết hàm tìm phần tử lẻ lớn nhất trong ma trận
            Console.WriteLine($"\nPhần tử lẻ lớn nhất trong ma trận: {PhanTuLeLonNhatTrongMaTran(arr1)}");

            //f. Viết hàm đếm số lần xuất hiện của phần tử x trong ma trận, với x được nhập từ
            //bàn phím.
            int phanTu = 0;
            Console.Write("\nNhập vào phần tử cần đếm SL xuất hiện trong ma trận: ");
            phanTu = int.Parse(Console.ReadLine());
            Console.WriteLine($"Số lượng lần xuất hiện của phần tử {phanTu} xuất hiện trong ma trận: {DemSolanXuatHienPhanTuX(arr1, phanTu)}");

            //g. Viết hàm sắp xếp ma trận theo thứ tự tăng dần từ trên xuống dưới và từ trái qua
            //phải theo phương pháp dùng mảng phụ.
            Console.WriteLine($"\nMa trận sao khi được sắp xếp theo thứ tự tăng dần từ trên xuống dưới và từ trái qua phải");
            SapXepTangDan(ref arr1);
            XuatMaTran(arr1);

            //h. Viết hàm sắp xếp các dòng trên ma trận theo thứ tự tăng dần.
            Console.WriteLine($"\nMa trận sau khi sắp xếp các dòng trên ma trận theo thứ tự tăng dần");
            SapXepTangDanCacDong(ref arr1, n, m);
            XuatMaTran(arr1);

        }

        static void SapXepTangDanCacDong(ref int[,] A, int n, int m)
        {
            for (int k = 0; k < m; k++)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = n - 1; j > i; j--)
                    {
                        if (A[k, j] < A[k, j - 1])
                        {
                            int temp = A[k, j];
                            A[k, j] = A[k, j - 1];
                            A[k, j - 1] = temp;
                        }
                    }
                }
            }
        }

        static void SapXepTangDan(ref int[,] arr)
        {
            int temp = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i / arr.GetLength(1), i % arr.GetLength(1)] > arr[j / arr.GetLength(1), j % arr.GetLength(1)])
                    {
                        temp = arr[i / arr.GetLength(1), i % arr.GetLength(1)];
                        arr[i / arr.GetLength(1), i % arr.GetLength(1)] = arr[j / arr.GetLength(1), j % arr.GetLength(1)];
                        arr[j / arr.GetLength(1), j % arr.GetLength(1)] = temp;
                    }
                }
            }
        }

        static int DemSolanXuatHienPhanTuX(int[,] arr1, int phanTu)
        {
            int dem = 0;
            foreach (var i in arr1)
            {
                if (i == phanTu)
                {
                    dem++;
                }
            }
            return dem;
        }

        static int PhanTuLeLonNhatTrongMaTran(int[,] arr)
        {
            int maxLe = 0;
            foreach (var i in arr)
            {
                if (i % 2 != 0 && maxLe < i)
                {
                    maxLe = i;
                }
            }
            return maxLe;
        }

        static double TrungBinhCacPhanTuChan(int[,] arr1)
        {
            double trungBinhChan = 0;
            int dem = 0;
            foreach (var i in arr1)
            {
                if (i % 2 == 0)
                {
                    dem++;
                    trungBinhChan += i;
                }
            }
            return trungBinhChan / dem;
            Console.WriteLine();
        }

        static double TongPhanTuSoNguyenTo(int[,] arr1)
        {
            double sum = 0;
            foreach (var i in arr1)
            {
                if (CheckSoNguyenTo(i) == true)
                {
                    sum += i;
                }
            }
            return sum;
            Console.WriteLine();
        }

        static bool CheckSoNguyenTo(int x)
        {
            if (x == 1)
            {
                return false;
            }
            else
            {
                for (int i = 2; i <= Math.Sqrt(x); i++)
                {
                    if (x % i == 0)
                    {
                        return false;
                        break;
                    }
                }
            }
            return true;
        }

        static double TinhTichPhanTuCheoPhu(int[,] arr)
        {
            int i = arr.GetLength(1) - 1;
            int j = 0;
            double tich = 1;
            while (i >= 0)
            {
                tich *= arr[j, i];
                i--;
                j++;
            }
            return tich;
            Console.WriteLine();
        }

        static double TinhTichPhanTuCheoChinh(int[,] arr)
        {
            double tich = 1;
            int i = 0;
            while (i <= arr.GetLength(1) - 1)
            {
                tich *= arr[i, i];
                i++;
            }
            return tich;
            Console.WriteLine();
        }

        static void TinhPhanTuCuaCot(int[,] arr)
        {
            double tich = 1;
            int dem = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    tich = tich * arr[j, i];
                }
                dem++;
                Console.WriteLine($"Tích các phần tử của cột {dem}: {tich}");
                tich = 1;
            }
            Console.WriteLine();
        }

        static int[,] Coppy(int[,] arr, int m)
        {
            int[,] arr1 = new int[m, m];
            for (int i = 0; i < arr1.GetLength(0); i++)
            {
                for (int j = 0; j < arr1.GetLength(1); j++)
                {
                    arr1[i, j] = arr[i, j];
                }
            }
            return arr1;
        }

        static void XuatMaTran(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static int[,] NhapMaTran(int m, int n)
        {
            int[,] arr = new int[m, n];
            Random rand = new Random();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rand.Next(21);
                }
            }
            return arr;
        }
    }
}
