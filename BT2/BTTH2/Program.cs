
public class Program
{
    static void Main(string[] args)
    {
        Console.Write("Nhap duong dan : ");
        string path = Console.ReadLine() ?? "";

        if (Directory.Exists(path))
        {
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                long size = fileInfo.Length/1024;
                Console.WriteLine($"{Directory.GetCreationTime(file),-35} {size.ToString("N0"),-15} {file.Split(@"\").Last()}");
            }
            string[] folders = Directory.GetDirectories(path);
            foreach (string folder in folders)
            {
                Console.WriteLine($"{Directory.GetCreationTime(folder),-30} {"<DIR>", -20} {folder.Split(@"\").Last()}");
            }
        }
        else
        {
            Console.WriteLine($"Khong tim thay {path}");
        }
    }
}