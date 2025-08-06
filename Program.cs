using csharp_basics.Services;
using csharp_basics.Repositories;

class Program
{
    static void Main(string[] args)
    {
        EmployeeRepository employeeRepository = new EmployeeRepository();
        PayrollRepository payrollRepository = new PayrollRepository();

        PositionService positionService = new PositionService(employeeRepository);
        EmployeeService employeeService = new EmployeeService(employeeRepository, positionService);
        PayrollService payrollService = new PayrollService(employeeRepository, payrollRepository, positionService);

        while (true)
        {
            Console.WriteLine("\n=========== MAIN MENU ===========");
            Console.WriteLine("1. Employee Management");
            Console.WriteLine("2. Payroll System");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");
            string input = Console.ReadLine()!;

            switch (input)
            {
                case "1":
                    employeeService.EmployeeMenu();
                    break;
                case "2":
                    payrollService.PayrollMenu();
                    break;
                case "3":
                    Console.WriteLine("Exiting program. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid input. Please choose 1, 2, or 3.");
                    break;
            }
        }
    }
}
