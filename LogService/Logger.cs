public class Logger : ILogger
{
    private readonly Guid instaceId = Guid.NewGuid();
    public void Info(string message)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Info: " + message + " ---instance id: " + instaceId);
        Console.ResetColor();
    }
    public void Warning(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Warning: " + message + " ---instance id: " + instaceId);
        Console.ResetColor();
    }
    public void Error(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Error: " + message + " ---instance id: " + instaceId);
        Console.ResetColor();
    }
}