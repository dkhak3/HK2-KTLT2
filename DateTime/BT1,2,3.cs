using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datetime
{
    class BT1_2_3
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            
            Cau1();
            Console.WriteLine("---------------------------");
            Console.WriteLine();

            Cau2();
            Console.WriteLine("---------------------------");
            Console.WriteLine();

            Cau3();
            Console.WriteLine("---------------------------");

        }

        static void Cau3()
        {

            DateTime ngayPhaiTra = new DateTime();
            DateTime ngayTra = new DateTime();


            Console.Write("Ngày An phải trả sách: ");
            ngayPhaiTra = DateTime.Parse(Console.ReadLine());

            Console.Write("Ngày An trả sách: ");
            ngayTra = DateTime.Parse(Console.ReadLine());

            double ngayTre = (ngayTra - ngayPhaiTra).TotalDays;

            if (ngayTre <= 0)
            {
                Console.WriteLine("An trả sách đúng hạn");
            }
            else
            {
                Console.WriteLine($"An trả sách trể: {ngayTre} ngày");
            }


        }

        static void Cau2()
        {
            DateTime datatime = DateTime.Now;

            Console.WriteLine($"Today is: {datatime}");

            Console.WriteLine($"Ngày trước của 1 ngày: {datatime.AddDays(1)}");

            Console.WriteLine($"Ngày sau của 1 ngày: {datatime.AddDays(-1)}");

        }

        static void Cau1()
        {
            DateTime datatime = DateTime.Now;
            int weekDay = (int)datatime.DayOfWeek;

            Console.WriteLine($"Ngày trong tuần: {weekDay}");
            Console.WriteLine($"Today is: {datatime}");
        }
    }
}
