using Ontap_lab5;
using System;

namespace Lab5
{
    class Program
    {



        static void Bai_Shape()
        {
            ds_Rectangle ds = new ds_Rectangle();
            ds.Nhap_ds();
            ds.XapSep();
            ds.Xuat_ds();
            ds.XoaPtuDau();
            ds.XapSep();
            ds.Xuat_ds();
            ds.Addptu();
            ds.XapSep();
            ds.Xuat_ds();
            ds.TinhTong();
        }
        static void Bai_Maytinh()
        {
            bool Chon;
            Console.WriteLine("Nhap True = Laptop | false = Macbook: ");
            Chon = Convert.ToBoolean(Console.ReadLine());
            if (Chon)
            {
                DS_Laptop lt = new DS_Laptop();
                lt.Nhap_ds1();
                lt.SapXep();
                lt.Xuat_ds1();
                lt.XoaPtuDau();
                lt.Xuat_ds1();
                lt.TongSoLuong();
            }
            else
            {
                DS_Macbook m = new DS_Macbook();
                m.Nhap_ds2();
                m.SapXep();
                m.Xuat_ds2();
                m.TongSoLuong();
            }
        }
        static void HocPhann()
        {
            DS_HocPhan hp = new DS_HocPhan();
            hp.NhapDS();
            hp.XuatDS();
        }
        static void Main(string[] args)
        {
            //Bai_Shape();
            //Bai_Maytinh();
            HocPhann();
        }
    }
}