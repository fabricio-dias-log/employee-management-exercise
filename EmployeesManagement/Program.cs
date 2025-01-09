using System.Globalization;
using EmployeesManagement.Entities;

namespace EmployeesManagement;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter the number of employees: ");
        
        int n = int.Parse(Console.ReadLine());
        List<Employee> employees = new List<Employee>();
        
        
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Employee #{i+1} data: ");
            Console.Write("Outsourced (y/n)? ");
            char ch = char.Parse(Console.ReadLine());
            Console.Write("Name: ");
            string name = Console.ReadLine();
                
            Console.Write("Hours: ");
            int hours = int.Parse(Console.ReadLine());
                
            Console.Write("Value per hour: ");
            double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            
            if (ch == 'y' || ch == 's')
            {
                Console.Write("Additional charge: ");
                double additionalCharge = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                
                Employee outsourcedEmployee = new OutsourcedEmployee(name,hours,valuePerHour,additionalCharge);
                employees.Add(outsourcedEmployee);
            }
            
            if (ch == 'n')
            {                
                Employee employee = new Employee(name,hours,valuePerHour);
                
                employees.Add(employee);
            }
            Console.WriteLine("--------------------------------------------------------");
        }

        Console.WriteLine("");
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine("Payments:");
        foreach (var employee in employees)
        {
            Console.WriteLine($"{employee.Name} - ${employee.Payment().ToString("F2", CultureInfo.InvariantCulture)}");
        }
    }
}