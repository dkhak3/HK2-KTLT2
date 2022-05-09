using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String
{
    class BT2
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string kyTu;
            Console.Write("Nhập vào chuỗi ký tự tùy ý: ");
            kyTu = Convert.ToString(Console.ReadLine());

            //2. Viết hàm đếm số ký tự là chữ hoa có trong chuỗi.
            Console.WriteLine($"số ký tự là chữ hoa có trong chuỗi: {DemSoKyTuInHoaChuoi(kyTu)} ");
            
        }

        static int DemSoKyTuInHoaChuoi(string kyTu)
        {
            int dem = 0;
            for (int i = 0; i < kyTu.Length; i++)
            {
                if (kyTu[i] >= 'A' && kyTu[i] <= 'Z')
                {
                    dem++;
                }
            }
            return dem;
        }
    }
}
