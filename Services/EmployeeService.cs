using csharp_basics.Interfaces;
using csharp_basics.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_basics.Services
{
    internal class EmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public void AddEmployee()
        {
            Console.WriteLine("\n==================================ADDING EMPLOYEE==================================");
            var employee = InputEmployee();

            
            employeeRepository.Add(employee);
        }

        public void GetAllEmployees()
        {

            Console.WriteLine("\n==================================RETRIEVING EMPLOYEES==================================");
            var employees = employeeRepository.GetAll();

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
                string idInput = Console.ReadLine()!;

                if (!int.TryParse(idInput, out int id))
                {
                    throw new ArgumentException("Employee ID must be a valid number.");
                }

                Console.Write("Enter Employee Name: ");
                string name = Console.ReadLine()!;
                Console.Write("Enter Employee Email: ");
                string email = Console.ReadLine()!;
                Console.Write("Enter Employee Department: ");
                string department = Console.ReadLine()!;

                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(department))
                {
                    throw new ArgumentException("All fields are required.");
                }

                return new EmployeeEntity(id, name, email, department);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}. Please try again.\n");
                return InputEmployee();
            }
        }
    }
}
