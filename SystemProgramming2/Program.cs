using System.Diagnostics;
using System.Threading;
namespace SystemProgramming2;

class Program
{
    static Process[] processes;
    static Process selectedProcess;
    static void Main(string[] args)
    {
        Console.WriteLine("Process Viewer");
        Console.WriteLine("Data loading...");
        
        new Thread(() => {
            processes = Process.GetProcesses();
            Console.WriteLine("Ready!Press Enter to continue...");
        }).Start();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Process List:");
            
            if (processes != null)
            {
                foreach (var p in processes)
                {
                    try
                    {
                        Console.WriteLine($"{p.Id,8} | {p.ProcessName,20} | {p.WorkingSet64/1024/1024,4} MB");
                    }
                    catch {  }
                }
            }
            else
            {
                Console.WriteLine("Waiting for data...");
            }

            Console.WriteLine("\nEter process ID to view details (0 to exit):");
            if (int.TryParse(Console.ReadLine(), out int inputId))
            {
                if (inputId == 0) break;
                ShowProcessDetails(inputId);
            }
        }
    }
    static void ShowProcessDetails(int pid)
    {
        try
        {
            var p = Process.GetProcessById(pid);
            Console.Clear();
            Console.WriteLine($"Process details {pid}:");
            Console.WriteLine($"Name: {p.ProcessName}");
            Console.WriteLine($"Start: {p.StartTime}");
            Console.WriteLine($"Priorety: {p.PriorityClass}");
            Console.WriteLine($"Memory: {p.WorkingSet64/1024/1024} MB");
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
        catch
        {
            Console.WriteLine("Eror: Process not found.");
            Console.ReadLine();
        }
    }
}

///////
//Реалізуйте віконний додаток, який у вигляді дерева виводить список усіх процесів, запущених в операційній системі. Дерево має відбивати зв'язок між процесами.
//Кореневі вузли дерева мають бути представлені процесами, в яких відсутні батьківські процеси, а їх дочірні вузли мають представляти їх дочірні процеси.
//Передбачте у вікні виведення інформації про той процес, який виділено у дереві.
//Реалізуйте програму так, щоб алгоритм отримання інформації про процеси виконувався в дочірньому потоці і не зупиняв роботу первинного потоку додатка, в якому реалізовано інтерфейс користувача.
//Інакше кажучи, дочірній потік має повинен буде вибудовувати структуру процесів в елементі керування TreeView паралельно з тим, як первинний потік виводитиме інформацію про обраний користувачем процес.
//////
