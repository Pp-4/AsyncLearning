using System.Threading.Tasks;
using static System.Console;

namespace AsyncLearning.Examples;

public static class TaskFileRead
{
    public static async void Run()
    {
        string path = "../../../Assets/example.bmp";
        WriteLine($"metoda sync: {GetBitmapWidth(path)}");
        WriteLine($"metoda async: {await GetBitmapWidthAsync(path)}");
    }
    public static int GetBitmapWidth(string path)
    {
        using (var file = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            var fileId = new byte[2];
            var read = file.Read(fileId, 0, 2);
            if (read != 2 || fileId[0] != 'B' || fileId[1] != 'M')
                throw new Exception("Not a BMP file");
            file.Seek(18, SeekOrigin.Begin);
            var widthBuffer = new byte[4];
            read = file.Read(widthBuffer, 0, 4);
            if (read != 4) throw new Exception("Not a BMP file");
            return BitConverter.ToInt32(widthBuffer, 0);
        }
    }
    public static async Task<int> GetBitmapWidthAsync(string path)
    {
        using (var file = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            var fileId = new byte[2];
            var read = await file.ReadAsync(fileId, 0, 2);
            if (read != 2 || fileId[0] != 'B' || fileId[1] != 'M')
                throw new Exception("Not a BMP file");
            file.Seek(18, SeekOrigin.Begin);
            var widthBuffer = new byte[4];
            read = await file.ReadAsync(widthBuffer, 0, 4);
            if (read != 4) throw new Exception("Not a BMP file");
            return BitConverter.ToInt32(widthBuffer, 0);
        }
    }
}
