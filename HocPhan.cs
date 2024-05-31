using System;

namespace Lab5
{
    class HocPhan
    {
        string MaHP, TenHP;
        int SoTC;

        public HocPhan(string maHP = "", string tenHP = "", int soTC = 0)
        {
            MaHP = maHP;
            TenHP = tenHP;
            SoTC = soTC;
        }
        public override string ToString()
        {
            return MaHP + "\t" + TenHP + "\t" + SoTC;
        }
    }

    class DS_HocPhan
    {
        int n;
        List<HocPhan> ds;

        public void NhapDS()
        {
            FileStream f = new FileStream(@"D:\hocphan.txt", FileMode.Open);
            StreamReader sr = new StreamReader(f);
            n = int.Parse(sr.ReadLine());
            ds = new List<HocPhan>(n);
            for(int i = 0; i < n; i++)
            {
                string s = sr.ReadLine();
                string[] rr = s.Split(";");
                HocPhan hp = new HocPhan(rr[0], rr[1], int.Parse(rr[2]));
                ds.Add(hp);
            }
        }
        public void XuatDS()
        {
            foreach(var hp in ds)
            {
                Console.WriteLine(hp.ToString());
            }
        }
    }
}