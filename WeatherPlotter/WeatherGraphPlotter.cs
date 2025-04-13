using System;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace WeatherPlotter
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Графік температури ===");

            if (!File.Exists("weather_data.json"))
            {
                Console.WriteLine("Помилка: файл даних не знайдено!");
                return;
            }

            string json = File.ReadAllText("weather_data.json");
            var weatherData = JsonSerializer.Deserialize<OpenMeteoResponse>(json);

            // Виводимо температуру по годинах
            for (int i = 0; i < weatherData.hourly.time.Length; i++)
            {
                string time = weatherData.hourly.time[i];
                float temp = weatherData.hourly.temperature_2m[i];
                Console.WriteLine($"{time}: {temp}°C | {new string('■', (int)temp)}");
            }

            // Зберігаємо графік у файл
            File.WriteAllLines("weather_graph.txt", 
                weatherData.hourly.time.Select((t, i) => 
                    $"{t}: {weatherData.hourly.temperature_2m[i]}°C | {new string('■', (int)weatherData.hourly.temperature_2m[i])}"));
        }
    }

    public class OpenMeteoResponse
    {
        public HourlyData hourly { get; set; }
    }

    public class HourlyData
    {
        public string[] time { get; set; }
        public float[] temperature_2m { get; set; }
    }
}