namespace SystemProgramming2;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Press any key to start the game...");
        Console.WriteLine("Press any key when you see the signal!");
        Console.ReadKey();
        Console.Clear();

        Random random = new Random();
        int delay = random.Next(1000, 5000);
        
        Thread thread = new Thread(() =>
        {
            Thread.Sleep(delay);
            Console.WriteLine("Press the key!");
        });
        thread.Start();

        DateTime startTime = DateTime.Now;
        Console.ReadKey();
        DateTime endTime = DateTime.Now;

        TimeSpan reactionTime = (endTime - startTime);
        
        Console.WriteLine($"Your reaction time is: {reactionTime.TotalMilliseconds} ms");
        
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}

///////
//Реалізуйте консольний, ігровий додаток «Встиг — Не встиг», який перевірятиме швидкість реакції користувача.
//Програма подає сигнал користувачу у вигляді тексту, користувач натискає кнопку на клавіатурі.
//Після натискання користувач повинен побачити, скільки мілісекунд йому знадобилося, щоб натиснути кнопку.
//////