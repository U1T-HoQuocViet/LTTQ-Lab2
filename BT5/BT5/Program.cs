
public class Program
{
    static void Main(string[] args)
    {
        BatDongSan[] arr;

        Console.Write("Nhap so bat dong san : ");
        int n = Utils.NhapSN();

        arr = new BatDongSan[n];
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(" - Nhap loai bds : ");
            int choice = Utils.NhapSN();
            switch (choice)
            {
                case 0:
                    arr[i] = new KhuDat();
                    break;
                case 1:
                    arr[i] = new NhaPho();
                    break;
                case 2:
                    arr[i] = new ChungCu();
                    break;
                default:
                    break;
            }
            arr[i].Nhap();
        }

        Console.WriteLine("- Danh sach cac bat dong san :");
        foreach(BatDongSan b in arr)
            b.Xuat();

        Console.Write("- Tong gia ban : " + TongGiaBan(arr));
        Console.WriteLine();

        XuatDK(arr);

        TimKiem(arr);

    }

    static int TongGiaBan(BatDongSan[] a)
    {
        int sum = 0;
        foreach(BatDongSan b in a)
            sum += b.GetGiaBan();
        
        return sum;
    }

    static void XuatDK(BatDongSan[] a)
    {

        Console.WriteLine("- Danh sach cac khu dat co dien tich > 100m2 va nha pho co dien tich > 60m2 co nam xay dung >= 2019 : ");

        foreach (BatDongSan b in a)
        {
            if (b.GetType() == typeof(KhuDat) && b.GetDienTich() > 100)
                b.Xuat();
            else if(b.GetType() == typeof(NhaPho))
            {
                if ((b as NhaPho)?.GeTNamXayDung() >= 2019 && b.GetDienTich() > 60)
                    b.Xuat();
            }
        }
    }

    static void TimKiem(BatDongSan[] a)
    {
        Console.WriteLine("Nhap thong tin can tim :");
        Console.Write("Dia diem : ");string _diaDiem = Console.ReadLine() ?? "";
        Console.Write("Gia : "); int _gia = Utils.NhapSN();
        Console.Write("Dien tich : "); int _dienTich = Utils.NhapSN();

        Console.WriteLine(" - Danh sach cac bat dong san can tim : ");

        foreach (BatDongSan b in a)
        {
            if (b.GetDiaDiem().ToLower() == _diaDiem.ToLower())
                if (b.GetGiaBan() <= _gia && b.GetDienTich() >= _dienTich)
                    b.Xuat();
        }
    }
}

public static class Utils
{
    public static int NhapSN() => Convert.ToInt32(Console.ReadLine());
}