using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class PhanSo
{
    int tuso = 1, mauso = 1;

    public void Nhap()
    {
        Console.WriteLine("Nhap phan so : ");
        tuso = Utils.NhapSN();
        mauso = Utils.NhapSN();
        RutGon();
    }

    public void Xuat()
    {
        if (tuso == 0)
        {
            Console.Write(0);
            return;
        }
        if (mauso == 1)
            Console.Write(tuso);
        else
            Console.Write(tuso+"/"+mauso);
    }

    static int UocSoChungLN(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);
        while (a != b)
        {
            if (a > b)
                a = a - b;
            else
                b = b - a;
        }
        return a;
    }

    void RutGon()
    {
        if (tuso == 0)
        {
            return;
        }
        int ucln = UocSoChungLN(tuso, mauso);

        mauso /= ucln;
        tuso /= ucln;

        if (mauso < 0)
        {
            tuso *= -1;
            mauso *= -1;
        }
    }

    public static PhanSo operator+(PhanSo a, PhanSo b)
    {
        PhanSo result = new PhanSo();
        result.tuso = a.tuso * b.mauso + a.mauso * b.tuso;
        result.mauso = a.mauso * b.mauso;
        result.RutGon();
        return result;
    }

    public static PhanSo operator-(PhanSo a, PhanSo b)
    {
        PhanSo result = new PhanSo();
        result.tuso = a.tuso * b.mauso - a.mauso * b.tuso;
        result.mauso = a.mauso * b.mauso;
        result.RutGon();
        return result;
    }

    public static PhanSo operator*(PhanSo a, PhanSo b)
    {
        PhanSo result = new PhanSo();
        result.tuso = a.tuso * b.tuso;
        result.mauso = a.mauso * b.mauso;
        result.RutGon();
        return result;
    }

    public static PhanSo operator/(PhanSo a, PhanSo b)
    {
        PhanSo result = new PhanSo();
        result.tuso = a.tuso * b.mauso;
        result.mauso = a.mauso * b.tuso;
        result.RutGon();
        return result;
    }

    public float GetValue() => (float)tuso / mauso;
}

