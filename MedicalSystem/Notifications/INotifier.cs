namespace MedicalSystem.Notifications;

internal interface INotifier
{
    void Send(string recipient, string message);
}
