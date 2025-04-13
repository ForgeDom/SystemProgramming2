namespace SystemProgramming2.Classes;

public class Bank
{
    private int _money;
    private string _name;
    private int _percent;

    public int Money
    {
        get => _money;
        set
        {
            _money = value;
            WriteToFile();
        }
    }

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            WriteToFile();
        }
    }

    public int Percent
    {
        get => _percent;
        set
        {
            _percent = value;
            WriteToFile();
        }
    }

    private void WriteToFile()
    {
        Task.Run(() =>
        {
            using (StreamWriter writer = new StreamWriter("bank.txt", true))
            {
                writer.WriteLine($"Name: {Name}, Money: {Money}, Percent: {Percent}");
            }
        });
    }
}