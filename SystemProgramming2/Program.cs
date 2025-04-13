using SystemProgramming2.Classes;

namespace SystemProgramming2;

class Program
{
    static void Main(string[] args)
    {
        Bank bank = new Bank();
        bank.Money = 1000;
        bank.Name = "My Bank";
        bank.Percent = 5;
        Console.WriteLine($"Bank Name: {bank.Name}, Money: {bank.Money}, Percent: {bank.Percent}");
        
        bank.Money = 2000;
        bank.Name = "Your Bank";
        bank.Percent = 10;
        Console.WriteLine($"Updated Bank Name: {bank.Name}, Money: {bank.Money}, Percent: {bank.Percent}");
        
        Thread.Sleep(2000);
        
        Console.WriteLine("Bank data written to file.");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}

///////
//Створіть клас Bank, в якому будуть наступні властивості: int money, string name, int percent.
//Побудуйте клас так, щоб при зміні однієї з властивостей класу, створювався новий потік, який записував дані про властивості класу у текстовий файл на жорсткому диску.
//Клас має інкапсулювати у собі всю логіку багатопотоковості.
//////