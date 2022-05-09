using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String
{
    class BT5
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string kyTu;
            Console.Write("Nhập vào chuỗi ký tự tùy ý: ");
            kyTu = Convert.ToString(Console.ReadLine());

            Console.WriteLine("\nChuỗi vừa nhập: ");
            Console.WriteLine(kyTu);

            //5. Viết hàm đảo ngược chuỗi.
            Console.WriteLine($"\nChuỗi sau khi đảo ngược:  ");
            DaoNguocChuoi(kyTu);
        }

        static void DaoNguocChuoi(string kyTu)
        {
            string[] arrS = kyTu.Split(' '); //arrS: [Nguyen] [Huu]...
            for (int i = arrS.Length - 1; i >= 0; i--)
            {
                Console.Write(arrS[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
