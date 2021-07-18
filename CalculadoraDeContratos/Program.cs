using CalculadoraDeContratos.Entities;
using CalculadoraDeContratos.Entities.Enums;
using System;

namespace CalculadoraDeContratos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name: ");
            string department = Console.ReadLine();

            Console.WriteLine("Enter worker data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel wl = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base salary: ");
            double baseSalary = double.Parse(Console.ReadLine());

            Department dept = new Department(department);
            Worker worker = new Worker(name, wl, baseSalary, dept);

            Console.Write("How many contracts to this worker? ");
            int numContracts = int.Parse(Console.ReadLine());

            for (int i = 0; i < numContracts; i++)
            {
                Console.WriteLine($"Enter #{i+1} contract data:");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine());
                Console.Write("Duration (hours): ");
                int duration = int.Parse(Console.ReadLine());
                HourContract contract = new(date, valuePerHour, duration);
                worker.AddContract(contract);
            }

            Console.Write("\nEnter month and year to calculate income (MM/YYYY): ");
            string[] monthYear = Console.ReadLine().Split("/");
            int month = int.Parse(monthYear[0]);
            int year = int.Parse(monthYear[1]);

            Console.WriteLine($"Name: {worker.Name}");
            Console.WriteLine($"Department: {worker.Department.Name}");
            Console.WriteLine($"Income for {month.ToString("D2")}/{year.ToString("D2")}: {worker.Income(year,month).ToString("F2")}");
        }

    }
}
