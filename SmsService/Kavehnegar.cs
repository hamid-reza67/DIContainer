
public class Kavehnegar : ISMS
{
    private readonly ILogger _logger;
    public Kavehnegar(ILogger logger) => _logger = logger;
    public bool SendSMS(string number, string text)
    {
        _logger.Info("Kavenegar SMS service log.");
        Console.WriteLine($"A sms sended to {number} by Kavehnegar service.");
        return true;
    }
}