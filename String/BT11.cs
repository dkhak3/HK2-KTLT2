using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*11. Viết chương trình cho phép người dùng nhập vào một chuỗi họ tên. Chương
trình tạo username và password tự động cho người dùng bằng các ghép phần
tên và phần họ, password mặc định được tạo ra bằng cách ghép các ký tự đầu
tiên của chuỗi họ tên và viết thường ghép với một số có 6 chữ số ngẫu nhiên.
Ví du: Họ tên: Nguyen Van Anh, username: AnhNguyen, password: nva261782
 */
namespace String
{
    class BT11
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string kyTu;
            Console.Write("Nhập vào họ và tên cần tạo username: ");
            kyTu = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine($"Username được tạo: {username(kyTu)}");
            Console.WriteLine($"Password được tạo: {Password(kyTu)}");

        }

        static string Password(string a)
        {
            char[] pass = new char[0];
            int k = 0;
            Random rand = new Random();
            var x = rand.Next(0, 1000000);
            string s = x.ToString("000000");
            for (int i = 0; i < a.Length; i++)
            {
                if (KiemTraKyTuInHoaChuoi(a[i]) == true)
                {
                    Array.Resize(ref pass, pass.Length + 1);
                    pass[k] = a[i];
                    k++;
                }
            }
            return string.Concat(new string(pass).ToLower(), s);
        }

        static string username(string a)
        {
            char[] username = new char[0];
            int k = 0;
            for (int i = a.Length - 1; i >= 0; i--)
            {
                if (a[i] == ' ' && k == 0)
                {
                    Array.Resize(ref username, a.Length - i);
                    for (int j = i + 1; j < a.Length; j++)
                    {
                        username[k] = a[j];
                        k++;
                    }
                }
            }
            for (int l = 0; l < a.Length; l++)
            {
                if (a[l] == ' ')
                {
                    break;
                }
                else
                {
                    Array.Resize(ref username, a.Length + 1);
                    username[k] = a[l];
                    k++;
                }


            }
            return new string(username);
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
