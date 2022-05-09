using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String
{
    class BT6
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string kyTu;
            Console.Write("Nhập vào chuỗi ký tự tùy ý: ");
            kyTu = Convert.ToString(Console.ReadLine());

            //6. Viết hàm đếm số từ trong một chuỗi. Biết từ do người dùng nhập vào từ bàn
            //phím.
            char tuNhap;
            Console.Write("\nNhập vào từ cần đếm: ");
            tuNhap = char.Parse(Console.ReadLine());

            Console.WriteLine($"\nsố lần xuất hiện của {tuNhap} trong chuỗi {kyTu}: {DemTuXuatHienTrongChuoi(kyTu, tuNhap)} ");

        }

        static int DemTuXuatHienTrongChuoi(string kyTu, char tuNhap)
        {
            int dem = 0;
            foreach (var i in kyTu)
            {
                if (i == tuNhap)
                {
                    dem++;
                }
            }
            return dem;
        }
    }
}
