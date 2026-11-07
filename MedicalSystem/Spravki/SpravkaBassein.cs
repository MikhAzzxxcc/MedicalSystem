using MedicalSystem.Interfaces;
using MedicalSystem.Users;

namespace MedicalSystem.Spravki;

internal class SpravkaBassein : ISpravka
{
    public string SpravkaName { get; set; } = string.Empty;
    public Patient Patient { get; set; } = null!;
    public decimal Price { get; set; }
    public int ValidMonths { get; set; }

    public decimal CalculatePrice() => Price;
    public string GetShortInfo() => $"{SpravkaName}: {CalculatePrice():0.00}";

    public void DisplayInfo()
    {
        Console.WriteLine($"Справка: {SpravkaName}");
        Console.WriteLine($"Пациент: {Patient.Name} {Patient.Surname}");
        Console.WriteLine($"Телефон: {Patient.PhoneNumber}");
        Console.WriteLine($"Группа крови: {Patient.BloodType}");
        Console.WriteLine($"Цена: {Price:0.00}");
        Console.WriteLine($"Действует месяцев: {ValidMonths}");
    }
}
