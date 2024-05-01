using System;

namespace Login
{

    class Program
    {
        static void log()
        {
            string n;
            string key;
            Console.WriteLine("Nhap vao mat khau: \t");
            n = Console.ReadLine();
            key = "123";
            string pass = key;
            byte maxlog = 3;
            if (n != pass)
            {
                for (int i = 0; i < maxlog; i++)
                {
                    Console.WriteLine("Mat khau khong chinh xac! \t");
                    if (i < maxlog)
                    {
                        Console.WriteLine("Vui long nhap lai mat khau: \t");
                        n = Console.ReadLine();
                        if (n == pass)
                        {
                            Console.WriteLine("\tDang nhap thanh cong!");
                            break;
                        }
                    }
                }
                if (n != pass)
                {
                    Console.WriteLine("\tBan da nhap qua so lan, hay thu lai sau 5 phut!");
                }
            }
            else
            {
                Console.WriteLine("\tDang nhap thanh cong!");
            }
        }
        static void Main(string[] args)
        {
            log();
        }
    }
}