using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String
{
    class BT8
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string kyTu;
            Console.Write("Nhập vào họ và tên: ");
            kyTu = Convert.ToString(Console.ReadLine());


            //8. Viết hàm tạo email từ chuỗi họ tên của người dùng. Biết email được tạo bằng
            //cách xoá các khoảng trắng trong chuỗi và thêm “@tdc.edu.vn”.
            Console.WriteLine($"hàm tạo email từ chuỗi họ tên của người dùng: ");
            Console.WriteLine(TaoMail(kyTu));

        }

        static string TaoMail(string kyTu)
        {
            // viết thường all
            kyTu = kyTu.ToLower();

            // kiểm tra có khoảng trắng và thay thế
            while (kyTu.IndexOf(' ') != -1)
            {
                kyTu = kyTu.Replace(" ", "");
            }

            // gán thêm chữ
            kyTu = kyTu + "@tdc.edu.vn";

            return kyTu;
        }
    }
}
