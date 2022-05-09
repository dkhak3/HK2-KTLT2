using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String
{
    class BT3
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string kyTu;
            Console.Write("Nhập vào chuỗi ký tự tùy ý: ");
            kyTu = Convert.ToString(Console.ReadLine());

            //3. Viết hàm đếm số ký tự là chữ số có trong chuỗi.
            Console.WriteLine($"số ký tự là chữ số có trong chuỗi: {DemSoKyTuChuSoChuoi(kyTu)} ");

        }

        static int DemSoKyTuChuSoChuoi(string kyTu)
        {
            int dem = 0;
            for (int i = 0; i < kyTu.Length; i++)
            {
                if (kyTu[i] >= '0' && kyTu[i] <= '9')
                {
                    dem++;
                }
            }
            return dem;
        }
    }
}
