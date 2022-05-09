/*KTLT2_Ch4_BT2.cs: Quản lý thông tin Thuê Bao và Gói Cước
* Name:
* Date:
*/
using System;

namespace KTLT2_Ch4_BT2
{
    class KTLT2_Ch4_BT2
    {
        //Khai báo structs
        public struct GoiCuoc
        {
            public string tenGoi;
            public int chuKyGoi;
            public double giaGoi;
            public bool vuotGoi;
            //Hàm khởi tạo giá trị cho các fields
            public GoiCuoc(string tenG, int ckGoi, double giaG, bool vuotG)
            {
                tenGoi = tenG;
                chuKyGoi = ckGoi;
                giaGoi = giaG;
                vuotGoi = vuotG;
            }
        }
        //struct ThueBao
        public struct ThueBao
        {
            public string hoTen;
            public string soCMND;
            public GoiCuoc goiCuocSD;
            //Hàm khởi tạo giá trị
            public ThueBao(string ten, string cmnd, GoiCuoc goiC)
            {
                hoTen = ten;
                soCMND = cmnd;
                goiCuocSD = goiC;
            }
        }
        static void Main(string[] args)
        {
            //GoiCuoc gC = NhapThongTinGoiCuoc();
            //Console.WriteLine(XuatGoiCuoc(gC));

            //Console.WriteLine(XuLyChuoiTen(" cao   dang thu     duc  "));
            //Console.WriteLine(KiemTraSoCMND("028462830"));


            ThueBao tB = NhapThongTinThueBao();
            Console.WriteLine(XuatThongTinThueBao(tB));

        }
        //1. Hàm Nhập thông tin một Gói cước
        public static GoiCuoc NhapThongTinGoiCuoc()
        {
            string tenGoi;
            int chuKyGoi;
            double giaGoi;
            bool vuotGoi;
            do
            {
                Console.Write("Nhap ten goi cuoc: ");
                tenGoi = Console.ReadLine();
            } while (tenGoi.Length <= 0 || tenGoi.Length > 10);

            //Tính chu kỳ goi
            chuKyGoi = ((int)tenGoi[tenGoi.Length - 1] - 48) * 30;
            do
            {
                Console.Write("Nhap gia goi cuoc: ");
                double.TryParse(Console.ReadLine(), out giaGoi);
            } while (giaGoi > 999999);

            Console.Write("Nhap vuot goi cuoc: ");
            bool.TryParse(Console.ReadLine(), out vuotGoi);
            GoiCuoc gC = new GoiCuoc(tenGoi, chuKyGoi, giaGoi, vuotGoi);
            return gC;
        }
        //2. Hàm xuất thông tin một  Gói cước
        public static string XuatGoiCuoc(GoiCuoc gC)
        {
            string s = $"{gC.tenGoi}-{gC.chuKyGoi}-{gC.giaGoi}-{gC.vuotGoi}";

            return s;
        }
        //3. Hàm Nhập thông tin một Thuê bao
        public static ThueBao NhapThongTinThueBao()
        {
            ThueBao tB = new ThueBao();
            //Nhap ho ten
            string tam = "";
            Console.Write("Nhap ten thue bao: ");
            tam = Console.ReadLine();
            tB.hoTen = XuLyChuoiTen(tam);
            //Nhap so CMND
            do
            {
                Console.Write("Nhap so CMND cua thue bao: ");
                tam = Console.ReadLine();
            } while (KiemTraSoCMND(tam) == false);
            tB.soCMND = tam;
            //Nhap thong tin goi cuoc
            tB.goiCuocSD = NhapThongTinGoiCuoc();
            return tB;
        }

        //Xử lý chuỗi Tên
        public static string XuLyChuoiTen(string str)
        {
            str = XoaKhoangTrangThua(str);
            str = HoaDauTu(str);
            return str;
        }
        //Xoa khoang trang thua
        public static string XoaKhoangTrangThua(string str)
        {
            //Xóa các khoảng trắng đầu và cuối chuỗi
            str = str.Trim();
            //Xóa khoảng trắng thừa giữa chuối
            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str[i] == ' ' && str[i + 1] == ' ')
                {
                    str = str.Remove(i, 1);
                    i--;
                }
            }
            return str;
        }

        //Kiem tra SoCMND
        public static bool KiemTraSoCMND(string soCMND)
        {
            //Kiem tra chieu dai
            if (soCMND.Length != 9)
            {
                return false;
            }
            //Kiem tra ky tu so
            foreach (var item in soCMND)
            {
                if (item < '0' || item > '9')
                {
                    return false;
                }
            }
            return true;
        }

        public static string HoaDauTu(string str)
        {
            char[] arrCh = str.ToCharArray();
            arrCh[0] = char.ToUpper(arrCh[0]);
            for (int i = 1; i < str.Length - 1; i++)
            {
                if (arrCh[i] == ' ' && arrCh[i + 1] != ' ')
                {
                    arrCh[i + 1] = char.ToUpper(arrCh[i + 1]);
                }
            }
            string s = new String(arrCh);
            return s;
        }
        //4. Hàm xuất thông tin một  Thuê bao
        public static string XuatThongTinThueBao(ThueBao tB)
        {
            string s = $"{tB.hoTen} - {tB.soCMND} - {XuatGoiCuoc(tB.goiCuocSD)}";
            return s;
        }
        //5. Hàm nhập danh sách Thuê bao
        //6. Hàm xuât danh sách Thuê bao
    }
}
