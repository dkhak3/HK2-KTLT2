using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String
{
    class BT7
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string kyTu;
            string kyTu2;
            Console.Write("Nhập vào chuỗi ký tự tùy ý: ");
            kyTu = Convert.ToString(Console.ReadLine());

            Console.Write("Nhập vào chuỗi ký tự tùy ý: ");
            kyTu2 = Convert.ToString(Console.ReadLine());

            //7. Viết hàm so sánh hai chuỗi không phân biệt chữ hoa, chữ thường. Hàm trả về
            //true nếu hai chuỗi giống nhau, ngược lại trả về false.
            Console.WriteLine($"hàm so sánh hai chuỗi không phân biệt chữ hoa, chữ thường: ");
            Console.WriteLine(CheckGiongNhau(kyTu, kyTu2));

        }

        static bool CheckGiongNhau(string kyTu, string kyTu2)
        {
            return string.Compare(kyTu.ToLower(), kyTu2.ToLower()) == 0;
        }
    }
}
