using System;

namespace TinhToanNhiPhan
{
    class Program
    {
        
        bool GetBit(int x, int i)
        {
            return (x >> i) & 1;
        }
        // Tìm dãy bit của x và gán vào mảng bit kết quả a
        void TimDayBit(int x, bool a[32])
        {
            int k = 0;
            for (int i = 31; i >= 0; i--)
            {
                bool bit = GetBit(x, i);
                a[k++] = bit;
            }
        }
        // Hàm xuất dãy bit
        void XuatDayBit(bool a[32])
        {
            for (int i = 0; i < 32; i++)
                printf("%d", a[i]);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
