using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTapFile
{
    internal class BT3_4
    {
        struct HangHoa
        {
            public int maHang;
            public string tenHang;
            public int soLuongBan;
            public double donGia;
            //public double thanhTien;

            public HangHoa(int maHang, string tenHang, int soLuongBan, double donGia)
            {
                this.maHang = maHang;
                this.tenHang = tenHang;
                this.soLuongBan = soLuongBan;
                this.donGia = donGia;
            }

        }
        static void Main()
        {
            HangHoa[] hangHoa;
            int n = 0;

            hangHoa = DocFileHangHoa(n);

            XuatMangHangHoa(hangHoa);
        }

        static void XuatMangHangHoa(HangHoa[] hangHoa)
        {
            for (int i = 0; i < hangHoa.Length; i++)
            {
                Console.WriteLine($"{"Ma Hang", -15}|{"Ten Hang", -15}|{"So Luong Ban", -15}|{"Don Gia", -15}|{"Thanh Tien", -15}");
                Console.WriteLine($"{hangHoa[i].maHang, -15}|{hangHoa[i].tenHang, -15}|{hangHoa[i].soLuongBan, -15}|{hangHoa[i].donGia+"$", -15}|{hangHoa[i].soLuongBan * hangHoa[i].donGia+"$"}");

                Console.WriteLine();

                using (StreamWriter sW = new StreamWriter($"HangHoa_{hangHoa[i].maHang}.txt"))
                {
                    sW.WriteLine($"{"Ma Hang",-15}|{"Ten Hang",-15}|{"So Luong Ban",-15}|{"Don Gia",-15}|{"Thanh Tien",-15}");
                    sW.WriteLine($"{hangHoa[i].maHang,-15}|{hangHoa[i].tenHang,-15}|{hangHoa[i].soLuongBan,-15}|{hangHoa[i].donGia + "$",-15}|{hangHoa[i].soLuongBan * hangHoa[i].donGia + "$"}");
                }
            }
        }


        static HangHoa[] DocFileHangHoa(int n)
        {
            HangHoa[] hangHoa;
            using (StreamReader sR = new StreamReader("HangHoa.txt"))
            {
                n = int.Parse(sR.ReadLine());

                hangHoa = new HangHoa[n];

                NhapMangHangHoaTuFile(hangHoa, sR);
            }
            return hangHoa;
        }

        static void NhapMangHangHoaTuFile(HangHoa[] hangHoa, StreamReader sR)
        {
            for (int i = 0; i < hangHoa.Length; i++)
            {
                hangHoa[i].maHang = int.Parse(sR.ReadLine());
                hangHoa[i].tenHang = sR.ReadLine();
                hangHoa[i].soLuongBan = int.Parse(sR.ReadLine());   
                hangHoa[i].donGia = double.Parse(sR.ReadLine());    
            }
        }
    }
}
