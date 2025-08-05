using csharp_basics.Services;
using csharp_basics.Repositories;

class Program
{
    static async Task Main(string[] args)
    {

        EmployeeRepository employeeRepository = new EmployeeRepository();

        EmployeeService employeeService = new EmployeeService(employeeRepository);


        await employeeService.AddEmployee();
        await employeeService.GetAllEmployees();






    }
}