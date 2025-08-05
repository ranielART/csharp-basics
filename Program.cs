using csharp_basics.Services;
using csharp_basics.Repositories;

class Program
{
    static void Main(string[] args)
    {

        EmployeeRepository employeeRepository = new EmployeeRepository();

        EmployeeService employeeService = new EmployeeService(employeeRepository);


        employeeService.AddEmployee();
        employeeService.GetAllEmployees();
        employeeService.FindEmployee();





    }
}