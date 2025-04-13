using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
namespace SystemProgramming2;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("=== Отримання даних про погоду ===");
        string url = $"https://api.open-meteo.com/v1/forecast?latitude=49&longitude=32&hourly=temperature_2m";

        using (HttpClient client = new HttpClient())
        {
            try
            {
                client.Timeout = TimeSpan.FromSeconds(30);
                string response = await client.GetStringAsync(url);
                File.WriteAllText("weather_data.json", response); 
                Console.WriteLine("Дані отримано! Запускаємо графік...");
                
                string exePath = @"E:\VS\RiderProjects\SystemProgramming2\WeatherPlotter\bin\Debug\net8.0\WeatherPlotter.exe";
                Process.Start(exePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }
    }
}

///////
//Реалізуйте додаток, який дозволить будувати графіки на основі таблиць даних. Наприклад, статистику зміни температури повітря протягом місяця.
//Додаток має складатися з двох незалежних складань і кожне з можливістю запускатись як самостійний додаток, і при цьому не повертати помилки.
//Створіть проєкт, який запустить ці додатки як пов'язані, у двох незалежних доменах додатків.
//Перший віконний додаток має приймати від користувача інформацію та ініціювати прорисовку графіка у другому додатку, який також має підтримувати можливість збереження отриманого графіка як зображення на жорсткий диск.
//Як принцип організації модульної структури додатка, можете скористатися прикладом, наведеним у розділі 6 цього уроку, але не варто одразу заперечувати альтернативні шляхи вирішення.
///////