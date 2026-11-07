namespace MedicalSystem.Notifications;

internal class ConsoleNotifier : INotifier
{
    private readonly string _channel;
    public ConsoleNotifier(string channel) => _channel = channel;

    public void Send(string recipient, string message)
    {
        Console.WriteLine($"{_channel} для {recipient}: {message}");
    }
}
