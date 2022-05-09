using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String
{
    class BT1
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string kyTu;
            Console.Write("Nhập vào chuỗi ký tự tùy ý: ");
            kyTu = Convert.ToString(Console.ReadLine());

            //1. Viết hàm đếm số ký tự có trong chuỗi .
            Console.WriteLine("Số ký tự có trong chuỗi: ");
            DemSoKyTuChuoi(kyTu);
        }

        static void DemSoKyTuChuoi(string kyTu)
        {
            Console.WriteLine(kyTu.Length);
        }
    }
}
