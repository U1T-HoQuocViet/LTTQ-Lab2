
public class Program
{
    static void Main(string[] args)
    {
        int month = Convert.ToInt32(Console.ReadLine());
        int year = Convert.ToInt32(Console.ReadLine());
        //int month = 12, year = 2018;
        int day = 1;

        int lenOfMonth = Date.GetLenOfMonth(month, year);
        int markDate = Date.DayOfWeek(day, month, year);

        Func<int, string> tr = x => (x/10 ==0) ? x+" " : x.ToString();

        Console.WriteLine("|--------||--------||--------||--------||--------||--------||--------|");
        Console.WriteLine("|  Sun   ||  Mon   ||  Tue   ||  Wed   ||  Thu   ||  Fri   ||  Sat   |");
        Console.WriteLine("|--------||--------||--------||--------||--------||--------||--------|");

        for(int i = 0; i < markDate; i++)
            Console.Write("|        |");

        int line = markDate == 0 ? 0 : 1;
        for (int i = markDate; day <= lenOfMonth; i++)
        {
            if(i % 7 == 0)
            {
                if(!(line == 0 && markDate == 0))
                {
                    Console.WriteLine();
                    Console.WriteLine("|--------||--------||--------||--------||--------||--------||--------|");
                }
                line++;
            }
            Console.Write($"|   {tr(day++)}   |");            
        }

        for (int i = 0; i < line*7 - markDate - lenOfMonth; i++)
            Console.Write("|        |");

        Console.WriteLine();
        Console.WriteLine("|--------||--------||--------||--------||--------||--------||--------|");

    }
}

public class Date
{
    static int[] lenOfMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };


    public static int GetLenOfMonth(int month, int year)
    {
        if (month > 12 || month < 1)
            return -1;
        return lenOfMonth[month - 1] + ((month == 2 && year % 4 == 0) ? 1 : 0);
    }

    // tinh thu trong tuan
    public static int DayOfWeek(int day, int month, int year)
    {
        // Cong thuc Zeller
        int y = year - (14 - month) / 12;
        int m = month + 12 * ((14 - month) / 12) - 2;
        int dayOfWeek = (day + y + y / 4 - y / 100 + y / 400 + (31 * m) / 12) % 7;

        return dayOfWeek;
    }
}
