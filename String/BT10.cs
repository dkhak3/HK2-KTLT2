using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String
{
    class BT10
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string kyTu;
            Console.Write("Nhập vào họ và tên cần tạo username: ");
            kyTu = Convert.ToString(Console.ReadLine());


            //10. Viết hàm kiểm tra chuỗi có hợp lệ hay không. Biết chuỗi hợp lệ là chuỗi không
            //có khoảng trắng đầu và cuối chuỗi, bắt đầu bằng ký tự chữ hoa và không chứa
            //hai khoảng trắng liên tiếp trong chuỗi.
            if (CheckChuoiHopLe(kyTu) == true)
            {
                Console.WriteLine("Chuỗi hợp lệ");
            }
            else
            {
                Console.WriteLine("Chuỗi không hợp lệ");
            }

        }

        static bool CheckChuoiHopLe(string a)
        {
            // check khoảng trắng đầu và cuối chuỗi && check không phải chữ hoa đầu chuổi
            if ((a[0] == ' ' || a[a.Length - 1] == ' ') && KiemTraKyTuInHoaChuoi(a[0]) == false)
            {
                return false;
            }
            for (int i = 0; i < a.Length; i++)
            {
                // check mỗi kí tự là có dấu cách
                if (a[i] == ' ' && a[i + 1] == ' ')
                {
                    return false;
                    break;
                }
                else if (a[i] == ' ' && KiemTraKyTuInHoaChuoi(a[i + 1]) == false)
                {
                    return false;
                    break;
                }
            }
            return true;
        }

        static bool KiemTraKyTuInHoaChuoi(char a)
        {
            if (char.IsUpper(a))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
