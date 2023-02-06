using ChuyenDoiHeCoSo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XuLySoNguyen
{
    class TinhToanSoNguyen
    {
        public static string ChuyenChuoi8Bit(int[]a )
        {
            string chuoi = "";
            foreach(int i in a)
            {
                chuoi += i;
            }
            return chuoi;
        }
        public static int[] ChuyenBu2KhongDau(int a)
        {
            int[] songuyen = chuyensonguyen8bit(a);

            for (int i = 7; i >= 0; i--)
            {

                if (songuyen[i] == 1) songuyen[i] = 0;
                else songuyen[i] = 1;
            }

            return TinhToanSoNguyen.TruSoNguyen(TinhToanSoNguyen.chuyenchuoisonhiphan(songuyen), chuyenchuoisonhiphan(chuyensonguyen8bit(1)));
        }
        public static int[] ChuyenSoNguyenBu2(int a)
        {
            // Chuyển đổi dãy số nguyên nhị phân dạng số nguyên sang dạng mảng các phần tử của số bù 2
            // Để dễ dàng thực hiện phép cộng trừ.
            int[] songuyen = chuyensonguyen8bit(a);

            for (int i = 7; i >= 0; i--)
            {

                if (songuyen[i] == 1) songuyen[i] = 0;
                else songuyen[i] = 1;
            }

            return TinhToanSoNguyen.CongSoNguyen(TinhToanSoNguyen.chuyenchuoisonhiphan(songuyen), chuyenchuoisonhiphan(chuyensonguyen8bit(1)));
            
        }
        public static int[] chuyensonguyen8bit(int a)
        {
            // Chuyển đổi dãy số nguyên nhị phân dạng số nguyên sang dạng mảng các phần tử của số
            // Để dễ dàng thực hiện phép cộng trừ.
            int[] arraybit = new int[8];
            int soa = (int)a;
            for (int i = 7; i >= 0; i--)
            {
                if (soa >= 0)
                    arraybit[i] = soa % 10;
                else
                    arraybit[i] = 0;
                soa /= 10;
            }
            return arraybit;
        }
        public static int chuyenchuoisonhiphan(int[]a)
        {
            // Chuyển dạng mảng của số nhị phân sang dạng số nguyên
            int chuoi = 0;
            for(int i = 0; i<=7;i++)
            {
                if (chuoi ==0 && a[i] == 0) continue;
                else
                    chuoi = chuoi * 10 + a[i];
            }
            return chuoi;
            
        }
        
        public static void XuatBit(int[] a)
        {
            //Xuất mảng ra màn hình
            for(int i = 0; i<=7;i++)
            {
                Console.Write($"{a[i]} ");
            }
            
        }
        public static int[] CongSoNguyen(int soa , int sob)
        {
            //Phép cộng số nguyên và xuất ra dạng mảng.
            int[] a = chuyensonguyen8bit(soa);
            int[] b = chuyensonguyen8bit(sob);
            int[] sum = chuyensonguyen8bit(0);
            int bitnho = 0;
           for(int i = 7; i>=0; i--)
            {
                
               sum[i]= a[i] + b[i]+bitnho;
                bitnho = 0;
                if(sum[i]>1)
                {
                    if (sum[i] == 2)
                        sum[i] = 0;
                    else sum[i] = 1;
                    bitnho = 1;
                }
            }
           
            return sum;

        }
        public static int[] TruSoNguyen(int soa, int sob)
        {
            // Trừ số nguyên 2 số nguyên đưa về dạng mảng. xuất kết quả cũng dạng mảng.
            int[] a = chuyensonguyen8bit(soa);
            int[] b = chuyensonguyen8bit(sob);
            int[] hieu = chuyensonguyen8bit(0);
            int bitnho = 0;
            for(int i = 7;i>=0; i--)
            {
                hieu[i] = a[i] - b[i] - bitnho;
                bitnho = 0;
                if (hieu[i] < -1)
                {
                    if (hieu[i] == -2)
                        hieu[i] = 0;
                    else hieu[i] = 1;
                    bitnho = 1;
                }
            }
            return hieu;
        }
        public static int NhapSoBu2(int soa)
        {
            
            int a;
            if (soa > 0)
            {
                Console.Write($" =  {ChuyenHeCoSo.Dec2bin(Math.Abs(soa))} (BIN)");
                a = (int)ChuyenHeCoSo.Dec2bin(Math.Abs(soa));
            }

            else
            {
                Console.Write($" =  {TinhToanSoNguyen.chuyenchuoisonhiphan(TinhToanSoNguyen.ChuyenSoNguyenBu2((int)ChuyenHeCoSo.Dec2bin(Math.Abs(soa))))} (BIN) bù 2");
                a = TinhToanSoNguyen.chuyenchuoisonhiphan(TinhToanSoNguyen.ChuyenSoNguyenBu2((int)ChuyenHeCoSo.Dec2bin(Math.Abs(soa))));
            }
            return a;
        }
        public static void DichPhai(int[] a)
        {
            // Dịch các bít của số a sang phải
            for (int i = 16; i >= 1; i--)
            {
                a[i] = a[i - 1];
            }
        }

        
        public static int chuyenDec(int[] a)
        {
            // Chuyển chuỗi 16 bit về dạng thập phân
            int m = 0;
            int n = 1;
                      
            for (int i = 15; i >= 0; i--, n *= 2)
            {
                m += (a[i] * n);
            }

            if (m > 64)
            {
                m = -(256 - m);
                return m;
            }
            return m;
        }

        
        public static void ThemNho(int[] a, int[] b)
        {
            // phát thêm bộ nhớ cho số đủ 8 bit
            int bitnho = 0;
            for (int i = 8; i >= 0; i--)
            {
                int tamthoi = a[i] + b[i] + bitnho;
                a[i] = tamthoi % 2;
                bitnho = tamthoi / 2;
            }

        }
        
        public static int[] ChuyenNhiPhan(int a) // Chuyển định dạng về nhị phân và Trả về dạng chuỗi
        {
            int n = a;                                   
            var chuoi2 = Convert.ToString(n, 2);                        
            if (n < 0)//Xử lý số âm
            {                
                if (chuoi2.Length == 32)
                {
                    chuoi2 = chuoi2.Remove(1, 24);
                    chuoi2 = chuoi2.PadRight(16, '0');
                }                
                return chuoi2.Select(c => int.Parse(c.ToString())).ToArray();
            }

            if (chuoi2.Length == 32) // Xử lý chuyển dịch phải toàn bộ số và trả về mảng
            {
                chuoi2 = chuoi2.Remove(0, 8);               
                chuoi2 = chuoi2.PadRight(16, '0');                
                return chuoi2.Select(c => int.Parse(c.ToString())).ToArray();
            }

            if (chuoi2.Length < 8)
            {
                // If its lesss make it 8 bits long
                chuoi2 = chuoi2.PadLeft(8, '0');
                chuoi2 = chuoi2.PadRight(16, '0');                
                return chuoi2.Select(c => int.Parse(c.ToString())).ToArray();
            }
            return chuoi2.Select(c => int.Parse(c.ToString())).ToArray();
        }
        public static void Hienthi(int[] a, string bien)
        {
            Console.Write(bien + ": ");

            for (int i = 0; i < a.Length; i++)
            {

                if (i == 8)
                {
                    Console.Write(" ");
                }

                if (i == 16)
                {
                    Console.Write(" ");
                }

                Console.Write(a[i]);
            }
            Console.WriteLine();

        }
        public static void NhanSoNguyen(int a, int b)
        {
            int[] m = ChuyenNhiPhan(a); 
            int[] m2 = ChuyenNhiPhan(-a); 
            int[] q = ChuyenNhiPhan(b); 
            int[] Cong = new int[17];
            int[] Tru = new int[17]; 
            int[] kq = new int[17];             
            for (int i = 0; i < 16; i++)
            {
                Cong[i] = m[i];
                Tru[i] = m2[i];
            }
                       
            for (int i = 8; i <= 16; i++)
            {
                kq[i] = q[i - 8];
            }
            kq[16] = 0;
            Console.WriteLine("     A        Qo     Q1");
            Hienthi(Cong, "M");
            Hienthi(Tru, "Q");
            Hienthi(kq, "P");
            Console.WriteLine(" ");
            for (int i = 0; i < 8; i++)
            {
                if (kq[15] == 0 && kq[16] == 0)
                {                
                }
                if (kq[15] == 1 && kq[16] == 1)
                {                   
                }
                if (kq[15] == 1 && kq[16] == 0)
                {                    
                    Hienthi(Tru, "Q");
                    ThemNho(kq, Tru);

                }
                if (kq[15] == 0 && kq[16] == 1)
                {                   
                    Hienthi(Cong, "M");
                    ThemNho(kq, Cong);
                }              
                DichPhai(kq);
                Hienthi(kq, "P");
                Console.WriteLine();
            }           
            string ghepchuoi = string.Join("", kq);            
            if (ghepchuoi.Length >= 17)
            {
                string kquahe2 = ghepchuoi.Remove(ghepchuoi.Length - 1);
                Console.WriteLine("   -------------------");
                Console.Write($"KQ:{kquahe2}   là số bù 2 của :");
                
            }
            else
            {
                Console.Write($"KQ: {ghepchuoi}");
                
            }

        }

    }
}
