using csharp_basics.Interfaces;
using csharp_basics.Models.Entities;
using csharp_basics.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace csharp_basics.Services
{
    internal class EmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly PositionService positionService;

        public EmployeeService(IEmployeeRepository employeeRepository, PositionService positionService)
        {
            this.employeeRepository = employeeRepository;
            this.positionService = positionService;
        }

        public void EmployeeMenu()
        {
            while (true)
            {
                Console.WriteLine("\n======= EMPLOYEE MANAGEMENT =======");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. View All Employees");
                Console.WriteLine("3. Find Employee by ID");
                Console.WriteLine("4. Update Employee");
                Console.WriteLine("5. Delete Employee");
                Console.WriteLine("6. Exit to Main Menu");
                Console.Write("Select an option: ");
                string input = Console.ReadLine()!;

                switch (input)
                {
                    case "1":
                        AddEmployee();
                        break;
                    case "2":
                        GetAllEmployees();
                        break;
                    case "3":
                        FindEmployee();
                        break;
                    case "4":
                        UpdateEmployee();
                        break;
                    case "5":
                        DeleteEmployee();
                        break;
                    case "6":
                        Console.WriteLine("Returning to main menu...\n");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }


        public void AddEmployee()
        {   
            try
            {
              Console.WriteLine("\n==================================ADDING EMPLOYEE==================================");
                var employee = InputEmployee();

                if(employeeRepository.GetEmployeeById(employee.id) != null)
                {
                    throw new ArgumentException("This ID Already Exists!");
                }

                if (employeeRepository.GetEmployeeByEmail(employee.email) != null)
                {
                    throw new ArgumentException("This Email Already Exists!");
                }

                employeeRepository.Add(employee);
            Console.WriteLine($"Employee {employee.name} is added successfully!");
                
            } catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message} Please try again.\n");
            }
           
        }

        public void GetAllEmployees()
        {

            Console.WriteLine("\n==================================RETRIEVING EMPLOYEES==================================");
            var employees = employeeRepository.GetAll();

            foreach (var employee in employees) // For each loop
            {
                Console.WriteLine(employee.DisplayInfo());
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
                
                string position = positionService.SelectPositionFromMenu();

                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(position))
                {
                    throw new ArgumentException("All fields are required.");
                }
                
                return new EmployeeEntity(id, name, email, position);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message} Please try again.\n");
                return InputEmployee();
            }
        }

        public void FindEmployee()
        {
            try {
            Console.WriteLine("\n==================================FINDING EMPLOYEE==================================");
            Console.Write("Enter Employee ID: ");
            string idInput = Console.ReadLine()!;

            if (!int.TryParse(idInput, out int id)) {
                   throw new ArgumentException("Employee ID must be a valid number.");
            }
            
            var employee = employeeRepository.GetEmployeeById(id);
            
            if (employee == null){
                
            throw new ArgumentException($"No employee found with ID {id}.");

            }

            Console.WriteLine("Employee Found!");
            Console.WriteLine($"Employee Details: {employee.DisplayInfo()}");
                
            } catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message} Please try again.\n");
            }

        }
        public void UpdateEmployee()
        {   

            try
            {

            GetAllEmployees();
            Console.WriteLine("\n==================================UPDATING EMPLOYEE==================================");
            Console.Write("Enter Employee ID to edit: ");
            string idInput = Console.ReadLine()!;
            
            if (!int.TryParse(idInput, out int id))
            {
                throw new ArgumentException("Employee ID must be a valid number.");
            }

            var employee = employeeRepository.GetEmployeeById(id);

            if (employee == null)
            {
                throw new ArgumentException($"No employee found with ID {id}.");
            }

            Console.Write("Enter new employee name: ");
            string newName = Console.ReadLine()!;
            Console.Write("Enter new employee email: ");
            string newEmail = Console.ReadLine()!;
            Console.Write("Enter new employee poistion: ");
            string newPosition = positionService.SelectPositionFromMenu();


                if (string.IsNullOrWhiteSpace(newName) || string.IsNullOrWhiteSpace(newEmail) || string.IsNullOrWhiteSpace(newPosition))
            {
                throw new ArgumentException("All fields are required.");
            }
            
                
            Console.WriteLine($"Previous Data - Name: {employee.name}, Email: {employee.email}, Position: {employee.position}");
            Console.WriteLine($"New Data - Name: {newName}, Email: {newEmail}, Position: {newPosition}");
            Console.Write("Save Changes? y or n: ");
            string choice = Console.ReadLine()!;
            if (choice.ToLower() == "y")
            {
                employee.SetEmail(newEmail);
                employee.SetName(newName);
                employee.SetPosition(newPosition);
                Console.WriteLine("Employee updated successfully!\n");
            }
            else
            {
                Console.WriteLine("Changes not saved.\n");
            }


            } catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message} Please try again.\n");
            }

        }

        public void DeleteEmployee()
        {
            try
            {
                GetAllEmployees();
                Console.WriteLine("\n==================================DELETING EMPLOYEE==================================");
                Console.Write("Enter Employee ID to delete: ");
                string idInput = Console.ReadLine()!;
                if (!int.TryParse(idInput, out int id))
                {
                    throw new ArgumentException("Employee ID must be a valid number.");
                }
                var employee = employeeRepository.GetEmployeeById(id);
                if (employee == null)
                {
                    throw new ArgumentException($"No employee found with ID {id}.");
                }
                Console.WriteLine($"Are you sure you want to delete the following employee? {employee.DisplayInfo()} (y/n)");
                string choice = Console.ReadLine()!;
                
                if (choice.ToLower() == "y")
                {
                    employeeRepository.Delete(employee);
                    Console.WriteLine("Employee deleted successfully!\n");
                }
                else
                {
                    Console.WriteLine("Deletion cancelled.\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message} Please try again.\n");
            }
        }

    }
}
