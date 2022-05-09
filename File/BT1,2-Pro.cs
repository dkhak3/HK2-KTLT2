using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OnTapFile
{
    internal class BT1_2
    {
        static void Main()
        {
            int[] arr;
            int n = 0;

            arr = DocFile(n);

            GhiFile(arr);

            GhiFileXuatTongPTChan(arr);

            GhiFileXuatTongSoNguyenTo(arr);
        }

        static void GhiFileXuatTongSoNguyenTo(int[] arr)
        {
            int sum = 0;
            try
            {
                using (StreamWriter sW = new StreamWriter("TongSoNguyenTo.txt"))
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (CheckSoNguyenTo(arr[i]) == true)
                        {
                            sum += arr[i];
                        }
                    }

                    sW.WriteLine($"Tong cac so nguyen to trong mang: {sum}");
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Khong ghi duoc file");
            }
        }

        static void GhiFileXuatTongPTChan(int[] arr)
        {
            int sum = 0;
            try
            {
                using (StreamWriter sW = new StreamWriter("XuatPTChan.txt"))
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (arr[i] % 2 == 0)
                        {
                            sum += arr[i];
                        }
                    }


                    sW.WriteLine($"Tong cac phan tu o vi tri chan trong mang: {sum}");
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Khong ghi duoc file");
            }
        }

        static void GhiFile(int[] arr)
        {
            try
            {
                using (StreamWriter sW = new StreamWriter("XuatMangNguyen.txt"))
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        sW.Write(arr[i] + " ");
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Khong ghi duoc file");
            }
        }

        static int[] DocFile(int n)
        {
            int[] arr;
            using (StreamReader sR = new StreamReader("MangNguyen.txt"))
            {
                n = int.Parse(sR.ReadLine());
                arr = new int[n];

                NhapMangTuFile(arr, sR);
            }
            return arr;
        }

        static void NhapMangTuFile(int[] arr, StreamReader sR)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(sR.ReadLine());
            }
        }

        static int TongSoNguyenToTrongMang(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (CheckSoNguyenTo(arr[i]) == true)
                {
                    sum += arr[i];
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
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        static int TongPTOViTriChan(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    sum += arr[i];
                }
            }
            return sum;
        }

    }
}
