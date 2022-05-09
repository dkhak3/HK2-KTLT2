using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKII_KTLT2
{
    class BT3
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            int[,] arr;
            int size = 0;
            Console.Write("Nhập số đỉnh của đồ thị: ");
            size = int.Parse(Console.ReadLine());
            arr = NhapMang(size);
            XuatMang(arr);

            Console.WriteLine();
            if (KiemTraMaTranDaDoThi(arr) == true)
            {
                Console.WriteLine("Ma trận trên là ma trận Đa đồ thị");
            }
            else
            {
                Console.WriteLine("Ma trận trên không là ma trận Đa đồ thị");
            }
            Console.WriteLine();

            Console.WriteLine("Tổng từng dòng trong ma trận");
            int[] arrTongDong = TinhTongTungDongMaTran(arr);
            for (int i = 0; i < arrTongDong.Length; i++)
            {
                Console.WriteLine($"Tổng dòng {i}: {arrTongDong[i]}");
            }
            Console.WriteLine();

            Console.WriteLine("Kiểm tra Đồ thị có tồn tại một chu trình con hay không");
            if (KiemTraDoThiCoTonTaiMotChuTrinhCon(arr) == true)
            {
                Console.WriteLine("Đồ thị có tồn tại chu trình con");
            }
            else
            {
                Console.WriteLine("Đồ thị không tồn tại chu trình con");
            }
        }

        //d. Kiểm tra tồn tại chu trình con trong đồ thị
        //Kiểm tra tất cả các giá trị tổng dòng là số chẵn
        static bool KiemTraDoThiCoTonTaiMotChuTrinhCon(int[,] arr)
        {
            // tính tổng dòng
            int[] arrTongDong = TinhTongTungDongMaTran(arr);
            foreach (var item in arr)
            {
                //Trường hợp tồn tại một giá trị tổng dòng là số lẻ thì trả về false
                if (item % 2 != 0)
                {
                    return false;
                }
            }
            return true;
        }


        //c) Viết chương trình tính tổng các phần tử theo dòng (hoặc cột).
        static int[] TinhTongTungDongMaTran(int[,] arr)
        {
            // tạo mảng 1 chiều với số phần tử = kích thước ( số dòng ) của ma trận
            int[] arrTongDong = new int[arr.GetLength(0)];

            // tính tổng từng dòng
            int tongDong;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                tongDong = 0;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    tongDong += arr[i, j];
                }

                // lưu vào mảng kết quả
                arrTongDong[i] = tongDong;
            }
            return arrTongDong;
        }


        //b) Viết hàm kiểm tra ma trận trên có phải là ma trận của một Đa đồ thị hay
        //không.Biết đa đồ thị có ma trận với các phần tử nằm trên đường chéo chính
        //bằng 0 và trong ma trận có ít nhất một phần tử lớn hơn 1.
        static bool KiemTraMaTranDaDoThi(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                if (arr[i, i] != 0)
                {
                    return false;
                }
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    if (i != j && arr[i , j] > 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        static void XuatMang(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i,j] + " ");
                }
                Console.WriteLine();
            }
        }

        //a. Nhập mảng sau và in ma trận trên ra màn hình. Biết ma trận được thành lập theo nguyên tắc là phần tử A[i,j] = A[j,i].
        //Các phần tử trong ma trận là số nguyên lớn hơn 0.
        static int[,] NhapMang(int size)
        {
            // khai báo khởi đạo ma trận vuông
            int[,] arr = new int[size, size]; 

            // Nhập các phần tử cho ma trận 1/2 ma trận tam giác dưới
            // Gán các giá trị phần tử cho 1/2 ma trận tam giác trên
            for (int i = 0; i < size; i++)
            {
                // phần tử [i,j] với i <=j. Sau đó gán  phần tử đối diện theo chéo chính bằng bằng giá trị vừa nhập
                for (int j = 0; j <= i; j++) // j có giá trị từ 0 đến i
                {
                    Console.Write($"Nhập Arr[{i}, {j}]: ");
                    arr[i, j] = int.Parse(Console.ReadLine());
                    // gán giá trị cho phần tử [j ,i]
                    arr[j, i] = arr[i, j];
                }
                Console.WriteLine();
            }
            return arr;
        }
    }
}
