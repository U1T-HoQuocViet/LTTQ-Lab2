public class Program
{
    static void Main(string[] args)
    {
        Matrix a = new Matrix();
        a.NhapMaTran();
        a.XuatMaTran();

        Console.Write("Nhap phan tu can tim : ");
        int f = Convert.ToInt32(Console.ReadLine());
        a.TimPhanTu(f);
        a.XuatCacSNT();
        a.DongCoNhieuSNTNhat();
    }

    public class Matrix
    {
        int[,] mat;
        int n, m;

        public Matrix(int n = 1, int m = 1)
        {
            this.n = n;
            this.m = m;
        }

        public void NhapMaTran()
        {
            Console.WriteLine("Nhap so hang va cot cua ma tran :");
            n = Convert.ToInt32(Console.ReadLine());
            m = Convert.ToInt32(Console.ReadLine());

            mat = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    mat[i,j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        // xuat ma tran
        public void XuatMaTran()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write(mat[i, j] + " ");
                Console.WriteLine();
            }
        }
        
        public void TimPhanTu(int ele)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    if (mat[i, j] == ele)
                    {
                        Console.WriteLine($"Phan tu dang tim nam o vi tri ({i},{j}) .");
                        return;
                    }
            }
            Console.WriteLine($"Khong tim thay phan tu "+ ele);
        }

        public void XuatCacSNT()
        {
            Console.Write("Cac so nguyen to : ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    if (Utils.LaSNT(mat[i, j]))
                        Console.Write(mat[i,j] + " ");
            }
            Console.WriteLine();
        }

        public void DongCoNhieuSNTNhat()
        {
            int r = 0;
            int r_max = -1;
            for (int i = 0; i < n; i++)
            {
                int cnt = 0;
                for (int j = 0; j < m; j++)
                    if (Utils.LaSNT(mat[i, j]))
                        cnt++;
                if(cnt > r)
                {
                    r_max = i;
                    r = cnt;
                }
            }
            if (r_max == -1)
                Console.WriteLine("Khong co SNT");
            else
                Console.WriteLine($"Dong {r_max} co nhieu so nguyen to nhat.");
        }
    }
}

public class Utils
{
    public static bool LaSNT(int n)
    {
        if (n <= 1) return false;
        if (n == 2) return true;
        if (n % 2 == 0) return false;

        for (int i = 3; i * i <= n; i += 2)
        {
            if (n % i == 0)
                return false;
        }
        return true;
    }
}