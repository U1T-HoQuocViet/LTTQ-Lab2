
public class Program
{
    static void Main(string[] args)
    {
        //P1();
        P2();
    }

    static void P1()
    {
        PhanSo a = new PhanSo();
        PhanSo b = new PhanSo();
        a.Nhap();
        b.Nhap();

        Console.WriteLine("Tong 2 phan so : " + (a + b).GetValue());
        Console.WriteLine("Hieu 2 phan so : " + (a - b).GetValue());
        Console.WriteLine("Tich 2 phan so : " + (a * b).GetValue());
        Console.WriteLine("Thuong 2 phan so : " + (a / b).GetValue());
    }

    static void P2()
    {
        Console.WriteLine("Nhap so phan tu : ");
        int n = Utils.NhapSN();

        PhanSo[] arr = new PhanSo[n];
        Console.WriteLine("Nhap day phan so : ");
        for (int i = 0; i < n; i++)
        {
            arr[i] = new PhanSo();
            arr[i].Nhap();
        }
        Console.Write("Phan so lon nhat la : ");
        PSLonNhat(arr).Xuat();
        Console.WriteLine();

        Console.WriteLine("Day phan so da sap xep : ");
        SortPS(arr);
        for (int i = 0; i < n; i++)
        {
            arr[i].Xuat();
            Console.Write(' ');
        }
    }

    static PhanSo PSLonNhat(PhanSo[] a)
    {
        PhanSo t = a[0];
        for(int i  = 1; i < a.Length; i++)
            if(t.GetValue() <  a[i].GetValue()) 
                t = a[i];
        return t;
    }

    static void SortPS(PhanSo[] a)
    {
        for (int i = 0; i < a.Length; i++)
        { 
            for (int j = 0; j < a.Length - i - 1; j++)
            {
                if (a[j].GetValue() > a[j + 1].GetValue())
                {
                    (a[j], a[j + 1]) = (a[j + 1], a[j]);
                }
            }
        }
    }


}

public class Utils
{
    public static Func<int> NhapSN = () => Convert.ToInt32(Console.ReadLine());
}