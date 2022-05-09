using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKII_KTLT2
{
    class BT4
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            char[,] arr = new char[4, 4];
            int[] arr1 = new int[16];
            int nc = 0;
            int dem1 = 0;
            int dem = 0;
            Console.WriteLine("                  Trò chơi TicTacToe");
            Console.WriteLine("Quy ước người đầu tiên nhập là X và ng tiếp thep là O");
            Console.WriteLine("Ng chơi nhập 0-9");
            XuatMaTran(arr);
            do
            {
                if (dem % 2 == 0)
                {
                    while (KTTrungNhau(arr1, nc) == false)
                    {
                        Console.Write("Người thứ nhất nhập: ");
                        nc = Convert.ToInt32(Console.ReadLine());
                    }
                    arr[i(arr, nc), j(arr, nc)] = 'X';
                    arr1[dem1] = nc;
                    XuatMaTran(arr);
                    dem1++;
                }
                else
                {
                    while (KTTrungNhau(arr1, nc) == false)
                    {
                        Console.Write("Người thứ 2 nhập: ");
                        nc = Convert.ToInt32(Console.ReadLine());
                    }
                    arr[i(arr, nc), j(arr, nc)] = 'O';
                    arr1[dem1] = nc;
                    XuatMaTran(arr);
                    dem1++;
                }
                dem++;
            } while (dem <= arr.Length - 1);
        }

        static int j(char[,] arr, int nc)
        {
            int dem = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    dem++;
                    if (dem == nc)
                    {
                        return j;
                        break;
                    }
                }
            }
            return -1;
        }
        static int i(char[,] arr, int nc)
        {
            int dem = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    dem++;
                    if (dem == nc)
                    {
                        return i;
                        break;
                    }
                }
            }
            return -1;
        }
        static bool KTTrungNhau(int[] arr, int x)
        {
            foreach (int i in arr)
            {
                if (i == x)
                {
                    return false;
                    break;
                }
            }
            return true;
        }
        static void XuatMaTran(char[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (j == arr.GetLength(1) - 1)
                    {
                        Console.Write($"{arr[i, j]}");
                    }
                    else
                    {
                        Console.Write($"{arr[i, j]}|");
                    }
                }
                if (i == arr.GetLength(0) - 1)
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("- - - -");
                }
            }
        }
    }
}

