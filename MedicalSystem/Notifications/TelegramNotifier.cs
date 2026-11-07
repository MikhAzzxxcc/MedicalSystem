namespace MedicalSystem.Notifications;

internal class TelegramNotifier : INotifier
{
    public void Send(string recipient, string message)
    {
        Console.WriteLine($"Telegram для {recipient}: {message}");
    }
}
