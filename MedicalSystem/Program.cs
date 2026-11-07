
using MedicalSystem.Users;
using MedicalSystem.Spravki;
using MedicalSystem.Interfaces;
using MedicalSystem.Buhgalteria;
using MedicalSystem.Notifications;

Patient patient = new Patient("Aktan", "Asanov", "+996 555 123 456", "O(I) Rh+");
patient.DisplayInfo();

Spravka83 spravka83 = new Spravka83
{
    SpravkaName = "Spravka 83",
    Patient = patient,
    Price = 500
};

SpravkaSanknijka spravkaSanknijka = new SpravkaSanknijka
{
    SpravkaName = "Spravka Sanknijka",
    Patient = patient,
    Price = 1000,
    AnalysisCount = 3
};

List<ISpravka> spravkiList = 
    new List<ISpravka> { spravka83, spravkaSanknijka, new SpravkaBassein { SpravkaName = "Справка в бассейн", Patient = patient, Price = 200, ValidMonths = 6 } };

foreach (var spravka in spravkiList)
{
    spravka.DisplayInfo();
    Console.WriteLine($"Total Price: {spravka.CalculatePrice()}");
    Console.WriteLine();
}

Kassa kassa = new Kassa();

decimal totalAmount = kassa.Total(spravkiList);

Console.WriteLine($"Total Amount in Kassa: {totalAmount}");
Console.WriteLine("Краткий список справок:");
foreach (var spravka in spravkiList)
    Console.WriteLine(spravka.GetShortInfo());

Console.WriteLine();
kassa.PrintCheck(spravkiList);

Console.WriteLine();
Console.WriteLine("Выберите уведомление: 1 - Email, 2 - SMS, 3 - Telegram");
string? choice = Console.ReadLine();
INotifier notifier;
if (choice == "1")
    notifier = new ConsoleNotifier("Email");
else if (choice == "2")
    notifier = new ConsoleNotifier("SMS");
else
    notifier = new TelegramNotifier();
notifier.Send(patient.Name, "Ваша справка готова");
