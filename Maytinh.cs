using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ontap_lab5
{
    abstract class MayTinh
    {
        string Hang;
        private int ram;
        private int dungLuong;
        private int giaNhap;

        protected int Ram { get => ram; set => ram = value; }
        protected int DungLuong { get => dungLuong; set => dungLuong = value; }
        protected int GiaNhap { get => giaNhap; set => giaNhap = value; }

        public MayTinh(string hang = "", int ram = 0, int dungLuong = 0, int giaNhap = 0)
        {
            Hang = hang;
            Ram = ram;
            DungLuong = dungLuong;
            GiaNhap = giaNhap;
        }

        public virtual void Nhap()
        {
            Console.WriteLine("Nhap ten hang: ");
            Hang = Console.ReadLine();
            Console.WriteLine("Nhap so Ram: ");
            while(!int.TryParse(Console.ReadLine(), out ram) || ram < 0)
                    Console.WriteLine("Nhap lai so Ram > 0: ");
            Console.WriteLine("Nhap so dung luong: ");
            while (!int.TryParse(Console.ReadLine(), out dungLuong) || dungLuong < 0)
                Console.WriteLine("Nhap lai so dung luong > 0: ");
            Console.WriteLine("Gia nhap: ");
            while (!int.TryParse(Console.ReadLine(), out giaNhap) || giaNhap < 0)
                Console.WriteLine("Nhap lai so dung luong > 0: ");
        }
        public abstract double GiaBan();

        public virtual void Xuat()
        {
            Console.WriteLine($"Hang: {Hang}.\tRam: {ram}.\tDung luong: {dungLuong}.\tGia nhap: {giaNhap}");
        }
    }
    interface ILap
    {
        int kg { get; set; }
        double GiaBan();
    }
    sealed class Laptop : MayTinh, ILap, IComparable<Laptop>
    {
        int kg;
        int ILap.kg { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Kg { get => this.kg; set => this.kg = value; }
        public Laptop(int kg = 0, string hang = "", int ram = 0, int dungLuong = 0, int giaNhap = 0) : base(hang,ram,dungLuong,giaNhap)
        {
            this.kg = kg;
        }
        public new void Nhap1()
        {
            base.Nhap();
            Console.WriteLine("Nhap trong luong: ");
            while (!int.TryParse(Console.ReadLine(), out kg) || kg < 0 || kg > 5)
                Console.WriteLine("Nhap lai so dung luong < 5: ");
        }

        public override double GiaBan() 
        {
            if (kg >= 2)
                return GiaNhap + GiaNhap * 0.15;
            else
                return GiaNhap + GiaNhap * 0.20; 
        }
        public new void Xuat1()
        {
            base.Xuat();
            Console.WriteLine($"Trong luong: {kg}.\tGia ban: {GiaBan()}.");
        }
        public int CompareTo(Laptop other)
        {
            if (GiaBan() < other.GiaBan())
                return 1;
            else if (GiaBan() == GiaBan())
                return 0;
            else
                return -1;
        }
    }
    interface IMac
    {
        string Loai { get; set; }
        double GiaBan();

    }
    sealed class Macbook : MayTinh, IMac, IComparable<Macbook>
    {
        string Loai;

        string IMac.Loai { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Loai1 { get => Loai; set => Loai = value; }

        public Macbook(string loai = "", string hang = "", int ram = 0, int dungLuong = 0, int giaNhap = 0) : base(hang, ram, dungLuong, giaNhap)
        {
            Loai1 = loai;
        }

        public override void Nhap()
        {
            base.Nhap();
            Console.WriteLine("Nhap loai: ");
            Loai1 = Console.ReadLine();
        }
        public override double GiaBan()
        {
            if (Loai1 == "Macbook Pro 13 inch")
            {
                return GiaNhap + GiaNhap * 0.8;
            }
            else if (Loai1 == "Macbook Pro 16 inch")
            {
                return GiaNhap + GiaNhap * 0.5;
            }
            else
            {
                return 2 * GiaNhap;
            }
        }
        public new void Xuat2()
        {
            base.Xuat();
            Console.WriteLine($"Loai: {Loai1}.\tGia ban:{GiaBan()}.");
        }
        public int CompareTo(Macbook other)
        {
            if (GiaBan() < other.GiaBan())
                return 1;
            else if (GiaBan() == GiaBan())
                return 0;
            else
                return -1;
        }
    }

    class DS_Laptop
    {
        List<Laptop> ds;
        int n;
        public void Nhap_ds1()
        {
            Console.WriteLine("Nhap n: ");
            while (!int.TryParse(Console.ReadLine(), out n) || n < 2)
                Console.WriteLine("Nhap lai n: ");
            ds = new List<Laptop>(n);
            for (int i = 0; i < n; i++)
            {
                Laptop lt = new Laptop();
                lt.Nhap1();
                ds.Add(lt);
            }
        }
        public void Xuat_ds1()
        {
            foreach (var lt in ds)
                lt.Xuat1();
        }
        public void SapXep()
        {
            ds.Sort();
        }
        public void XoaPtuDau() // Xoa ptu dau nho hon gia ban
        {
            int x;
            Console.WriteLine("Nhap gia tien de xoa phan tu co so tien be hon: ");
            while (!int.TryParse(Console.ReadLine(), out x) || x < 0)
                Console.WriteLine("Nhap lai so tien > 0: ");
            foreach (var lt in ds)
                if (lt.GiaBan() <= x)
                {
                    ds.Remove(lt);
                    break;
                }
                    
                else
                {
                    Console.WriteLine(" ");
                }
        }
        public void AddPtu()
        {
            int i;
            Console.WriteLine("Nhap vi tri de them phan tu: ");
            while (!int.TryParse(Console.ReadLine(), out i) || i < 0)
                Console.WriteLine("Nhap lai vi tri: ");
            Laptop lt = new Laptop();
            lt.Nhap1();
            if(i < 0 || i > ds.Count)
            {
                Console.WriteLine(" ");
            }
            else
            {
                ds.Insert(i, lt);
            }
        }
        public void TongSoLuong()
        {
            int Dem = 0;
            foreach (var lt in ds)
                Dem++;
            Console.WriteLine($"So luong: {Dem}");
        }
    }
    class DS_Macbook
    {
        List<Macbook> ds;
        int n;
        public void Nhap_ds2()
        {
            Console.WriteLine("Nhap n: ");
            while (!int.TryParse(Console.ReadLine(), out n) || n < 2)
                Console.WriteLine("Nhap lai n: ");
            ds = new List<Macbook>(n);
            for (int i = 0; i < n; i++)
            {
                Macbook m = new Macbook();
                m.Nhap();
                ds.Add(m);
            }
        }
        public void Xuat_ds2()
        {
            foreach (var m in ds)
                m.Xuat2();
        }
        public void SapXep()
        {
            ds.Sort();
        }
        public void TongSoLuong()
        {
            int Dem = 0;
            foreach (var m in ds)
                Dem++;
            Console.WriteLine($"So luong: {Dem}");
        }
    }
}
