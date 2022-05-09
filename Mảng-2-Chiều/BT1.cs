using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKII_KTLT2
{
    class BT1
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            int hang = 0, cot = 0;
            char luaChon;
            int[,] arr;

            Nhap:  arr = Nhap(hang, cot);
            XuatMang(arr);

            KiemTraChoNgoi(arr);
            XuatMang(arr);

            Console.Write("Nhập Y or y để tiếp tục, nhập bất kì để kết thúc: ");
            luaChon = char.Parse(Console.ReadLine());
            if (luaChon == 'Y' || luaChon == 'y')
            {
                goto Nhap;
            }

        }


        static bool KiemTraChoNgoi(int[,] arr)
        {
            int chonHang = 0, chonGhe = 0;
            Console.Write("Nhập vào hàng muốn đặt: ");
            chonHang = int.Parse(Console.ReadLine());

            Console.Write("Nhập vào số ghế muốn đặt: ");
            chonGhe = int.Parse(Console.ReadLine());

            if (arr[chonHang, chonGhe] == 0)
            {
                arr[chonHang, chonGhe] = 1;
                Console.WriteLine("Đặt chổ thành công");
                return true;
            }
            Console.WriteLine("Đặt chổ không thành công \n Vui lòng chọn chỗ ngồi khác");
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

        static int[,] Nhap(int hang, int cot)
        {
            Console.Write("Nhập vào số lượng hàng: ");
            hang = int.Parse(Console.ReadLine());

            Console.Write("Nhập vào số lượng cột: ");
            cot = int.Parse(Console.ReadLine());

            int[,] arr = new int[hang, cot];
            return arr;
        }
    }
}
