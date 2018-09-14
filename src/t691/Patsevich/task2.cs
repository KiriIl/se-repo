using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace ConsoleApp5
{
    class task2
    {
        static string bar(int progress)
        {
            string load = "[";
            for (int i = 0; i < 100; i++)
            {
                if (i < progress)
                    load += "|";
                else
                    load += " ";
            }
            load += "]";
            return load;
        }
        static void list()
        {
            update:
            var mas = new List<PerformanceCounter>();
            int i = 0;
            Process[] procesi = Process.GetProcesses();
            procesi = Process.GetProcesses();
            foreach (Process proc in Process.GetProcesses())
            {
                var c = new PerformanceCounter("Process", "% Processor Time", proc.ProcessName);
                c.NextValue();
                mas.Add(c);
            }
            Console.WriteLine("{0,30}{1, 20}{2,20}{3,20}", "Название процесса", "id", "память (MB)", "загрузка процессора(%)");
            foreach (var counter in mas)
            {
                Console.WriteLine("{0,30}{1,20}{2,20}{3,20}", procesi[i].ProcessName, procesi[i].Id,
                    (procesi[i].WorkingSet64 / 1000) / 100, Convert.ToInt32(counter.NextValue()));
                i++;
            }
            Console.WriteLine("F3 - обновить, любая клавиша - назад");
            if (Console.ReadKey().Key == ConsoleKey.F3)
            { Console.Clear(); goto update; }
        }
        static void Main(string[] args)
        {
            PerformanceCounter cp = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            while (true)
            {
                Console.Clear();
                Console.WriteLine("F1 - спсико задач, F2 - обновить");
                int cpuse = Convert.ToInt32(cp.NextValue());
                Console.WriteLine("CP {0}%    {1,3}", cpuse, bar(cpuse));
                if (Console.ReadKey().Key == ConsoleKey.F1)
                { Console.Clear(); list(); }
            }
        }
    }
}
