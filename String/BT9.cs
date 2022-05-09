using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String
{
    class BT9
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string kyTu;
            Console.Write("Nhập vào chuỗi email: ");
            kyTu = Convert.ToString(Console.ReadLine());


            //9. Viết hàm kiểm tra chuỗi email do người dùng nhập vào có hợp lệ hay không.
            //Biết chuỗi email hợp lệ là chuỗi không chứa các ký tự đặc biệt như #, %, $,&,ˆ
            //, không có khoảng trắng nào trong chuỗi và bắt buộc phải có ký tự @ trong
            //chuỗi.
            if (CheckMailHopLe(kyTu) == true)
            {
                Console.WriteLine("Email hợp lệ");
            }
            else
            {
                Console.WriteLine("Email không hợp lệ");
            }

        }

        static bool CheckMailHopLe(string kyTu)
        {
            foreach (var i in kyTu)
            {
                if (i != ' ' ||
                i != '#' ||
                i != '%' ||
                i != '$' ||
                i != '&' ||
                i != '^' 
                )
                {
                    return true;
                }
            }
            return false;
        }
    }
}
