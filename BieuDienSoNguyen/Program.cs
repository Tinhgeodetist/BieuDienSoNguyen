using ChuyenDoiHeCoSo;
using System;
using System.Text;
using XuLySoNguyen;

namespace BieuDienSoNguyen

{
    
    class Program
    {
               
        
        static void Main(string[] args)
        {
            
            Console.OutputEncoding = Encoding.UTF8;           
            
            Console.WriteLine("        *Chức năng chuyển các dạng số nguyên không dấu: ");
            Console.WriteLine("1. Đổi Từ hệ 10 sang hệ 2");
            Console.WriteLine("2. Đổi Từ hệ 10 sang hệ 16");
            Console.WriteLine("3. Đổi Từ hệ 2 sang hệ 10");
            Console.WriteLine("4. Đổi Từ hệ 16 sang hệ 10");
            Console.WriteLine("5. Đổi Từ hệ 2 sang hệ 16");
            Console.WriteLine("6. Đổi Từ hệ 10 sang hệ 2");
            Console.WriteLine("        *Chức năng thực hiện phép tính số nhị phân 8bit bù 2 có dấu: ");
            Console.WriteLine("7. Phép cộng ");
            Console.WriteLine("8. Phép Trừ");
            Console.WriteLine("9. Phép Nhân");

            Console.Write(" Nhập vào lựa chọn [1-9] :");
            int n;
            Int32.TryParse(Console.ReadLine(), out n);
            while (n <=0|| n>9)
            {
                Int32.TryParse(Console.ReadLine(),out n);
            }
            switch(n)
            {
                case 1:
                    {
                        int dec = ChuyenHeCoSo.nhapthapphan();
                        Console.WriteLine($"->Số nguyên hệ thập phân [{dec}] chuyển sang hệ nhị phân là : {ChuyenHeCoSo.Dec2bin(dec)} ");
                        break;
                    }
                case 2:
                    {
                        int dec = ChuyenHeCoSo.nhapthapphan();
                        Console.WriteLine($"->Số nguyên hệ thập phân [{dec}] chuyển sang hệ thập lục phân là: {ChuyenHeCoSo.Dec2hex(dec)}");
                        break;                        
                    }
                case 3:
                    {
                        long bin = ChuyenHeCoSo.nhapbit();
                        Console.WriteLine($"->Số nguyên hệ nhị phân [{bin}] chuyển sang hệ thập phân là: {ChuyenHeCoSo.Bin2Dec(bin)}");

                        break;
                    }
                case 4:
                    {
                        string hex = ChuyenHeCoSo.nhaphex();
                        Console.WriteLine($"->Số nguyên hệ thập lục phân [{hex}] sang hệ thập phân là : {ChuyenHeCoSo.Hex2Dec(hex)}");
                        break;
                    }

                case 5:
                    {
                        long bin = ChuyenHeCoSo.nhapbit();
                        Console.WriteLine($"->Số nguyên hệ nhị phân [{bin}] sang hệ thập lục phân là : {ChuyenHeCoSo.Bin2Hex(bin)}");
                                                
                        break;
                    }
                case 6:
                    {
                        int dec = ChuyenHeCoSo.nhapthapphan();
                        Console.WriteLine($"->Số nguyên hệ thập phân [{dec}] sang hệ nhị phân là : {ChuyenHeCoSo.Dec2bin(dec)}");
                        break;
                    }
                case 7:
                    {
                        Console.WriteLine("Cộng 2 số a và b  ");
                        Console.Write("   Nhập số a (Hệ thập phân có dấu) ");
                        int soa = ChuyenHeCoSo.nhapthapphanam();
                        int a = TinhToanSoNguyen.NhapSoBu2(soa);
                        Console.WriteLine();
                        Console.Write("   Nhập số b (Hệ thập phân có dấu) ");
                        int sob = ChuyenHeCoSo.nhapthapphanam();
                        int b = TinhToanSoNguyen.NhapSoBu2(sob);
                        Console.WriteLine();                        
                        Console.WriteLine(" *Kết quả phép tính ở dạng nhị phân bù 2 ");
                        int kq= (TinhToanSoNguyen.chuyenchuoisonhiphan(TinhToanSoNguyen.CongSoNguyen(a, b)));
                        int kqtra = 0;
                        if (soa + sob < 0)
                        {
                            kqtra = TinhToanSoNguyen.chuyenchuoisonhiphan(TinhToanSoNguyen.ChuyenSoNguyenBu2((int)ChuyenHeCoSo.Dec2bin(Math.Abs(soa + sob))));
                        }
                        else
                            kqtra = (int)ChuyenHeCoSo.Dec2bin(soa + sob);
                        
                        Console.WriteLine($"     {(TinhToanSoNguyen.ChuyenChuoi8Bit(TinhToanSoNguyen.chuyensonguyen8bit(a)))}");
                        Console.WriteLine("    +");
                        Console.WriteLine($"     {(TinhToanSoNguyen.ChuyenChuoi8Bit(TinhToanSoNguyen.chuyensonguyen8bit(b)))}");
                        Console.WriteLine("     __________");
                        if (kqtra == kq)
                            Console.WriteLine($"     {TinhToanSoNguyen.ChuyenChuoi8Bit(TinhToanSoNguyen.chuyensonguyen8bit(kq))}  ({soa+sob})");
                        else
                        {
                            
                            Console.WriteLine("  => Tràn số");
                        }                            
                        
                        Console.WriteLine();
                        break;
                    }
                case 8:
                    {
                        Console.WriteLine("Trừ 2 số a và b  ");
                        Console.Write("   Nhập số a (Hệ thập phân có dấu) ");
                        int soa = ChuyenHeCoSo.nhapthapphanam();
                        int a = TinhToanSoNguyen.NhapSoBu2(soa);
                        Console.WriteLine();
                        Console.Write("   Nhập số b (Hệ thập phân có dấu) ");
                        int sob = -ChuyenHeCoSo.nhapthapphanam();
                        int b = TinhToanSoNguyen.NhapSoBu2(sob);
                        Console.WriteLine();
                        Console.WriteLine(" *Kết quả phép tính ở dạng nhị phân bù 2 ");
                        int kq = (TinhToanSoNguyen.chuyenchuoisonhiphan(TinhToanSoNguyen.CongSoNguyen(a, b)));
                        int kqtra = 0;
                        if (soa + sob < 0)
                        {
                            kqtra = TinhToanSoNguyen.chuyenchuoisonhiphan(TinhToanSoNguyen.ChuyenSoNguyenBu2((int)ChuyenHeCoSo.Dec2bin(Math.Abs(soa + sob))));
                        }
                        else
                            kqtra = (int)ChuyenHeCoSo.Dec2bin(soa + sob);

                        Console.WriteLine($"     {(TinhToanSoNguyen.ChuyenChuoi8Bit(TinhToanSoNguyen.chuyensonguyen8bit(a)))}");
                        Console.WriteLine("    -");
                        Console.WriteLine($"     {(TinhToanSoNguyen.ChuyenChuoi8Bit(TinhToanSoNguyen.chuyensonguyen8bit(b)))}");
                        Console.WriteLine("     __________");
                        if (kqtra == kq)
                            Console.WriteLine($"     {TinhToanSoNguyen.ChuyenChuoi8Bit(TinhToanSoNguyen.chuyensonguyen8bit(kq))}  ({soa + sob})");
                        else
                        {

                            Console.WriteLine("  => Tràn số");
                        }

                        Console.WriteLine();
                        break;

                    }
                case 9:
                    {
                        int M = 0; 
                        int Q = 0;                        
                        Console.Write("Số thứ nhất -> ");                        
                        Q = ChuyenHeCoSo.nhapthapphanam();
                        Console.Write("Số thứ nhất ->");
                        M = ChuyenHeCoSo.nhapthapphanam();
                        Console.WriteLine("Phép tính BOOTH: " + M + " * " + Q);                        
                        TinhToanSoNguyen.NhanSoNguyen(M, Q);
                        int kq   = M * Q;
                        Console.WriteLine($" {kq}");
                        
                        break;
                    }
                    
            }
           

        }
    }
}
