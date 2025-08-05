using csharp_basics.Controllers;
using csharp_basics.Interfaces;
using csharp_basics.Models.Entities;
using csharp_basics.Services;
using csharp_basics.Repositories;

class Program
{
    static async Task Main(string[] args)
    {

        EmployeeRepository employeeRepository = new EmployeeRepository();

        EmployeeService employeeService = new EmployeeService(employeeRepository);

        EmployeeController employeeController = new EmployeeController(employeeService);

        await employeeController.AddEmployee();

        await employeeController.GetAllEmployees();

        


    }
}