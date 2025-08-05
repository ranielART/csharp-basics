using csharp_basics.Models.Entities;
using csharp_basics.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_basics.Controllers
{
    internal class EmployeeController
    {
      private readonly EmployeeService employeeService;
        
        public EmployeeController(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public async Task AddEmployee()
        {
            Console.WriteLine("\n==================================ADDING EMPLOYEE==================================");
            var employee = InputEmployee(); 

            await employeeService.addEmployeeAsync(employee);

        }   
    
        public async Task GetAllEmployees()
        {
            Console.WriteLine("\n==================================RETRIEVING EMPLOYEES==================================");

            var employees = await employeeService.GetAllEmployeesAsync();

            foreach (var emp in employees)
            {
                Console.WriteLine(emp.DisplayInfo());
            }

        }

        public EmployeeEntity InputEmployee()
        {
            try
            {
            Console.Write("Enter Employee ID: ");
            int id = int.Parse(Console.ReadLine()!);
            Console.Write("Enter Employee Name: ");
            string name = Console.ReadLine()!;
            Console.Write("Enter Employee Email: ");
            string email = Console.ReadLine()!;
            Console.Write("Enter Employee Department: ");
            string department = Console.ReadLine()!;
                
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(department)) {
                Console.WriteLine("All fields are required. Please try again.");
                return InputEmployee();

            }



            return new EmployeeEntity(id, name, email, department);
                
            }
            catch (Exception ex)
            {
                return Task.FromException<EmployeeEntity>(ex).Result;
            }
        }
    }
}
