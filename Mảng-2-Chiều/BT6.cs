using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKII_KTLT2
{
    class BT6
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            int n = 0;
            Console.Write("Nhập vào chiều cao h: ");
            n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++) // Vòng lập để duyệt từng dòng. Dòng đầu tiên là dòng thứ 0.
            {
                for (int k = 0; k <= i; k++)// Với mỗi dòng, duyệt từng phần tử/ vị trí của số
                {
                    Console.Write(Pascal(k, i) + "   ");
                }
                Console.WriteLine("\n");
            }
        }

        /*C 0 n = C n n = 1
         * C k n = C k-1 n-1 + C k n-1; 
         */
        static int Pascal(int k, int n)
        {
            //C 0 n = C n n = 1
            if (k == 0 || k == n)
            {
                return 1;
            }
            else
            {
                //C k n = C k-1 n-1 + C k n-1; 
                return Pascal(k - 1, n - 1) + Pascal(k, n - 1);
            }
        }
    }
}
