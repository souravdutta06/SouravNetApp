// SouravNetApp/Program.cs
namespace SouravNetApp; // Correct namespace

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Hello Sourav");
        var builder = WebApplication.CreateBuilder(args);

        // Add this to explicitly bind to all interfaces
        builder.WebHost.UseUrls("http://0.0.0.0:80");

        var app = builder.Build();
    }
    
}
