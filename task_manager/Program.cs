using System.Diagnostics;


class Program
{
    static void Get_processes()
    {
        foreach (Process process in Process.GetProcesses())
        {
            Console.WriteLine($"ID: {process.Id}  Name: {process.ProcessName}");
        }
    }

    static void Kill_Process()
    {
        Console.Write("Введите процесс, который необходимо уничтожить: ");
        string s1 = Console.ReadLine();
        int processId;
        if (!int.TryParse(s1, out processId))
        {
            Console.WriteLine("Ошибка ввода. Введен некорректный ID процесса.");
            return;
        }
        else
        {
            processId = int.Parse(s1);
        }
        try
        {
            Process.GetProcessById(processId).Kill();
            Console.WriteLine($"Процесс с ID {processId} успешно завершен.");
        }
        catch (ArgumentException)
        {
            Console.WriteLine($"Процесс с ID {processId} не найден.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при завершении процесса: {ex.Message}");
        }
    }

    static void Instruction()
    {
        Console.Write("Инструкция: \n0. Выход из программы\n1. Вывод всех процессов \n2. Уничтожить процесс по ID\n");
    }

    static void Main(string[] args)
    {
        Instruction();
        while (true)
        {
            string n1 = Console.ReadLine();
            int n;
            if (!int.TryParse(n1, out n))
            {
                Console.Write("Ошибка ввода.\n");
                Instruction();
            }
            else
            {
                switch (n)
                {
                    case 0:
                        Console.WriteLine("Выход из программы...");
                        return;
                    case 1:
                        Get_processes();
                        Instruction();
                        break;
                    case 2:
                        Kill_Process();
                        Instruction();
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод");
                        Instruction();
                        break;
                }
            }
        }
    }
}