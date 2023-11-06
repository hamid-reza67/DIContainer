public class Melipayamak : ISMS
{
    private readonly ILogger _logger;
    public Melipayamak(ILogger logger) => _logger = logger;
    public bool SendSMS(string number, string text)
    {
        _logger.Info("Melipayamak SMS service log.");
        Console.WriteLine($"A sms sended to {number} by Melipayamak service.");
        return true;
    }
}