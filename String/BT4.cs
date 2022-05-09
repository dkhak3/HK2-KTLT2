using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String
{
    class BT4
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string kyTu;
            Console.Write("Nhập vào chuỗi ký tự tùy ý: ");
            kyTu = Convert.ToString(Console.ReadLine());

            //4. Viết hàm cho phép kiểm tra Chuỗi có tồn tại ký tự char hay không, biết char do
            //người dùng nhập vào từ bàn phím.
            char nhapKyTuCheck;
            Console.Write("\nNhập vào ký tự cần kiểm tra có tồn tại trong chuỗi không: ");
            nhapKyTuCheck = char.Parse(Console.ReadLine());
            Console.WriteLine();

            if (CheckKyTuCoTonTaiTrongChuoi(kyTu, nhapKyTuCheck) == true)
            {
                Console.WriteLine($"Ký tự {nhapKyTuCheck} có tồn tại trong chuỗi {kyTu}");
            }
            else
            {
                Console.WriteLine($"Ký tự {nhapKyTuCheck} không tồn tại trong chuỗi {kyTu}");
            }

        }

        static bool CheckKyTuCoTonTaiTrongChuoi(string kyTu, char nhapKyTuCheck)
        {
            foreach (var i in kyTu)
            {
                if (i == nhapKyTuCheck)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
