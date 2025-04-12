using System.Collections;

namespace SystemProgramming2;

class Program
{
    
    static void Main(string[] args)
    {

        List<object> list = new List<object>{"Hello", 1233, "there", DateTime.Now};
        Thread thread = new Thread(() =>
        {
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
                Thread.Sleep(1000);
            }
        });
        thread.Start();
        thread.Join();
    }
}

///////
//Створіть потік, який «приймає» колекцію елементів, викликає з кожного елемента колекції метод ToString() і виводить результат роботи методу на екран.
///////