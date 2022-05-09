using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*5. Viết chương trình khởi tạo giá trị các phần tử là ngẫu nhiên cho ma trận các số
nguyên kích thước m × n.
 */
namespace HKII_KTLT2
{
    class BT5
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            int[,] arr;
            int hang = 0, cot = 0;
            Console.Write("Nhập vào số lượng hàng: ");
            hang = int.Parse(Console.ReadLine());

            Console.Write("Nhập vào số lượng cột: ");
            cot = int.Parse(Console.ReadLine());

            arr = NhapMang(hang, cot);

            Console.WriteLine("Xuất mảng các phần tử ngẫu nhiên: ");
            XuatMang(arr);
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

        static int[,] NhapMang(int hang, int cot)
        {
            int[,] arr = new int[hang, cot];
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
    }
}
