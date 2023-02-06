using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChuyenDoiHeCoSo
{
    public class ChuyenHeCoSo
    {
        /*=> Chuyển hệ 2 sang hệ 16:
         *          Nhóm từng 4 bit hệ 2 và chuyển sang hệ 16,
         *          Sử dụng phương thức chuyển từ hề 2 sang 10 và 10 sang 16.
        */
        public static string Bin2Hex(long a)
        {
            long b = a;
            string hex = "";
            while (b > 1)
            {
                int sodu = (int)(b % 10000);
                hex = Dec2hex(Bin2Dec(sodu)) + hex;
                b = b / 10000;
            }
            return hex;
        }

        // => Chuyển hệ 16 sang hệ 10
        //          Lấy tùng giá trị bit trong hệ 16 và chuyển về hệ thập phân
        //          Sau đó lấy giá trị Nhân với cơ số 16 lũy thừa thứ tự bit
        //          Cộng chúng lại với nhau ta được hệ 10
        public static int Hex2Dec(string a)
        {
            int Dec = 0;
            for (int i = 0; i < a.Length; i++)
            {
                string sktu = a.Substring(i, 1).ToUpper();
                int ktu = 0;
                switch (sktu)
                {
                    case "A":
                        {
                            ktu = 10;
                            break;
                        }
                    case "B":
                        {
                            ktu = 11;
                            break;
                        }
                    case "C":
                        {
                            ktu = 12;
                            break;
                        }
                    case "D":
                        {
                            ktu = 13;
                            break;
                        }
                    case "E":
                        {
                            ktu = 14;
                            break;
                        }
                    case "F":
                        {
                            ktu = 15;
                            break;
                        }
                };
                if (ktu == 0) ktu = int.Parse(sktu);
                Dec += ktu * (int)Math.Pow(16, a.Length - i - 1);

            }
            return Dec;
        }

        // => Chuyển hệ thập phân sang hệ 10
        //                      Lấy số cuối của hệ 10 bằng cách chia lấy số dư
        public static int Bin2Dec(long a)
        {
            long sobin = a;
            long Dec = 0;
            for (int i = 0; i < a.ToString().Length; i++)
            {
                Dec += sobin % 10 * (int)Math.Pow(2, i);
                sobin /= 10;
            }

            return (int)Dec;
        }
        //=> Chuyển hệ 10 sang hệ 2
        //                       Lấy số hệ 10 chia 2 lấy dư nếu 1 thì giá trị bằng 1 và 0 là 0 sau đó nối chúng lại với nhau
        public static long Dec2bin(int a)
        {            
                long b = 0;
                int p = 0;
                while (a > 0)
                {
                    b += (a % 2) * (int)Math.Pow(10, p);
                    p++;
                    a /= 2;
                }
                return b;            
        }
        //=> Chuyển hệ 10 sang hệ 16
        //          Lấy số hệ 10 chia 16 lấy dư 
        //          Nối chuỗi số dư ta được số hệ 16
        public static string Dec2hex(int a)
        {

            int d;
            string hex = "";
            int dv = 1;
            while (a > 0)
            {
                d = a % 16;
                if (dv == 1)
                {
                    string ktu = "";
                    if (d > 9)
                    {
                        switch (d)
                        {
                            case 10:
                                {
                                    ktu = "A";
                                    break;
                                }
                            case 11:
                                {
                                    ktu = "B";
                                    break;
                                }
                            case 12:
                                {
                                    ktu = "C";
                                    break;
                                }
                            case 13:
                                {
                                    ktu = "D";
                                    break;
                                }
                            case 14:
                                {
                                    ktu = "E";
                                    break;
                                }
                            case 15:
                                {
                                    ktu = "F";
                                    break;
                                }
                        };
                        hex = ktu;
                    }
                    else
                        hex = d.ToString();
                }
                else
                {
                    string ktu = "";
                    if (d > 9)
                    {
                        switch (d)
                        {
                            case 10:
                                {
                                    ktu = "A";
                                    break;
                                }
                            case 11:
                                {
                                    ktu = "B";
                                    break;
                                }
                            case 12:
                                {
                                    ktu = "C";
                                    break;
                                }
                            case 13:
                                {
                                    ktu = "D";
                                    break;
                                }
                            case 14:
                                {
                                    ktu = "E";
                                    break;
                                }
                            case 15:
                                {
                                    ktu = "F";
                                    break;
                                }
                        };
                        hex = $"{ktu + hex}";
                    }
                    else
                        hex = $"{d + hex}";
                }
                a = a / 16;
                dv = dv * 10;
            }
            return hex;
        }
        public static long nhapbit() // Nhập vào dãy bit 10101 có kiểm tra đầu vào
        {
            long bitxuat = 0;
            try
            {
                Console.Write(" Nhập vào dãy số nhị phân: ");
                long bit = long.Parse(Console.ReadLine());
                int sodu = (int)(bit % 10);
                long bitxuly = bit;
                while (bit <= 0)
                {
                    if (sodu > 1)
                    {
                        Console.WriteLine("Định dạng không phải dãy nhị phân. Xin mời nhập lại!");
                        bit = nhapbit();
                        break;
                    }
                }
                while (bitxuly > 0)
                {
                    sodu = (int)(bitxuly % 10);
                    bitxuly = bitxuly / 10;
                    if (sodu > 1)
                    {
                        Console.WriteLine("Định dạng không phải dãy nhị phân. Xin mời nhập lại!");
                        bit = nhapbit();
                        break;
                    }
                }
                bitxuat = bit;
            }
            catch
            {
                Console.WriteLine("Định dạng không phải dãy nhị phân. Xin mời nhập lại!");

            }
            finally
            {
                if (bitxuat <= 0)
                {
                    bitxuat = nhapbit();
                }

            }

            return bitxuat;

        }
        public static string nhaphex()// Nhập vào số nguyên HEX, có kiểm tra đầu vào.
        {
            Console.WriteLine("Nhập vào số HEX: ");
            string hex = Console.ReadLine();
            string[] hexdemo = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", };
            for (int i = 0; i <= hex.Length - 1; i++)
            {
                int e = 0;
                string hexcheck = hex.Substring(i, 1);
                foreach (string k in hexdemo)
                {
                    if (hexcheck == k) e++;

                }
                if (e == 0)
                {
                    Console.WriteLine("Không phải định dạng số Hex. Nhập lại!");
                    hex = nhaphex();
                    break;
                }

            }
            return hex;
        }
        public static int nhapthapphan()// Nhập vào số nguyên, có kiểm tra đầu vào.
        {
            int stp = 0;
            try
            {
                Console.Write(" Nhập vào số thập phân: ");
                stp = int.Parse(Console.ReadLine());

                while (stp <= 0)
                {
                    Console.WriteLine("Không phải số nguyên dương:");
                    stp = nhapthapphan();
                    break;
                }

            }
            catch
            {
                Console.WriteLine("Sai cú pháp nhập. Xin nhập lại!");
            }
            finally
            {
                if (stp <= 0)
                    stp = nhapthapphan();

            }
            return stp;

        }
        public static int nhapthapphanam()// Nhập vào số nguyên, có kiểm tra đầu vào của số bù 2 có dấu
        {
            int stp = 0;
            try
            {
                Console.Write(" Nhập vào số thập phân: ");
                stp = int.Parse(Console.ReadLine());

                while (stp == 0 || stp > 127 || stp<-128)
                {
                    Console.WriteLine("Số quá khoảng lưu trữ 8 bit");
                    stp = nhapthapphanam();
                    break;
                }

            }
            catch
            {
                Console.WriteLine("Sai cú pháp nhập. Xin nhập lại!");
            }
            finally
            {
                if (stp == 0)
                    stp = nhapthapphanam();

            }
            return stp;

        }
    }
}
