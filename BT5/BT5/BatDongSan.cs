using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class BatDongSan
{
    protected string diaDiem;
    protected int giaBan;
    protected int dienTich;

    public virtual void Nhap() 
    {
        diaDiem = Console.ReadLine() ?? "";
        giaBan = Utils.NhapSN();
        dienTich = Utils.NhapSN();
    }

    public virtual void Xuat()
    {
        Console.WriteLine(" + Dia diem : " + diaDiem);
        Console.WriteLine(" + Gia ban : " + giaBan + " VND");
        Console.WriteLine(" + Dien tich : " + dienTich + " m2");
    }

    public int GetGiaBan() => giaBan;
    public int GetDienTich() => dienTich;
    public string GetDiaDiem() => diaDiem;
}

public class KhuDat : BatDongSan
{
    public override void Nhap()
    {
        Console.WriteLine("Nhap thong tin khu dat : ");
        base.Nhap();
    }

    public override void Xuat()
    {
        Console.WriteLine("Thong tin khu dat : ");
        base.Xuat();
    }
}

public class NhaPho : BatDongSan
{
    int namXayDung;
    int soTang;

    public int GeTNamXayDung() => namXayDung;

    public override void Nhap()
    {
        Console.WriteLine("Nhap thong tin nha pho : ");
        base.Nhap();
        namXayDung = Utils.NhapSN();
        soTang = Utils.NhapSN();
    }

    public override void Xuat()
    {
        Console.WriteLine("Thong tin nha pho : ");
        base.Xuat();
        Console.WriteLine($" + Duoc xay dung vao nam {namXayDung}");
        Console.WriteLine(" + So tang : " + soTang);

    }
}

public class ChungCu : BatDongSan
{
    int tang;
    public override void Nhap()
    {
        Console.WriteLine("Nhap thong tin chung cu : ");
        base.Nhap();
        tang = Utils.NhapSN();
    }

    public override void Xuat()
    {
        Console.WriteLine("Thong tin nha dat : ");
        base.Xuat();
        Console.WriteLine($" + Dang o tang {tang}");
    }
}

