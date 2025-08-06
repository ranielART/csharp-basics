using csharp_basics.Interfaces;
using csharp_basics.Models.Entities;
using csharp_basics.Repositories;
using System;
using System.Collections.Generic;

namespace csharp_basics.Services
{
    internal class PayrollService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly PayrollRepository payrollRepository;
        private readonly PositionService positionService;
        public PayrollService(IEmployeeRepository employeeRepository, PayrollRepository payrollRepository, PositionService positionService)
        {
            this.employeeRepository = employeeRepository;
            this.payrollRepository = payrollRepository;
            this.positionService = positionService;
        }

        public void PayrollMenu()
        {
            while (true)
            {
                Console.WriteLine("\n========== PAYROLL SYSTEM ==========");
                Console.WriteLine("1. Pay an Employee");
                Console.WriteLine("2. View Payroll History");
                Console.WriteLine("3. Exit to Main Menu");
                Console.Write("Select an option: ");
                string input = Console.ReadLine()!;

                switch (input)
                {
                    case "1":
                        PayEmployee();
                        break;
                    case "2":
                        ViewPayrollHistory();
                        break;
                    case "3":
                        Console.WriteLine("Returning to main menu...\n");
                        return; 
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        public void PayEmployee()
        {
            try
            {
                var employees = employeeRepository.GetAll();

                if (employees.Count == 0)
                {
                    Console.WriteLine("\nNo employees available to pay.\n");
                    return;
                }

                Console.WriteLine("\n============== PAY EMPLOYEE ==============");

                for (int i = 0; i < employees.Count; i++)
                {
                    var emp = employees[i];
                    Console.WriteLine($"{i + 1}. ID: {emp.id} | Name: {emp.name} | Position: {emp.position}");
                }

                Console.Write("\nSelect employee number to pay: ");
                string input = Console.ReadLine()!;

                if (!int.TryParse(input, out int selection) || selection < 1 || selection > employees.Count)
                {
                    throw new ArgumentException("Invalid selection. Please enter a valid number from the list.");
                }

                var selected = employees[selection - 1];

                Console.WriteLine($"\nSelected Employee:");
                Console.WriteLine($"Name     : {selected.name}");
                Console.WriteLine($"Position : {selected.position}");
                Console.WriteLine($"Salary   : PHP {positionService.GetSalaryByPosition(selected.position):N2}");

                Console.Write("Confirm payment? (y/n): ");
                string confirm = Console.ReadLine()!;

                if (string.IsNullOrWhiteSpace(confirm) || (confirm.ToLower() != "y" && confirm.ToLower() != "n"))
                {
                    throw new ArgumentException("Invalid confirmation input. Please type 'y' or 'n'.");
                }

                if (confirm.ToLower() == "y")
                {
                    int payrollId = payrollRepository.GenerateNextId();
                    var payroll = new PayrollEntity(
                        id: payrollId,
                        employee_id: selected.id,
                        employee_name: selected.name,
                        position: selected.position,
                        amount_paid: positionService.GetSalaryByPosition(selected.position)
                    );

                    payrollRepository.Add(payroll);

                    Console.WriteLine($"\nPayment successful!");
                    Console.WriteLine(payroll.DisplayEmployeePay());
                }
                else
                {
                    Console.WriteLine("\nPayment cancelled.\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}\n");
            }
        }

        public void ViewPayrollHistory()
        {
            try
            {
                var records = payrollRepository.GetAll();

                Console.WriteLine("\n============== PAYROLL HISTORY ==============");

                if (records.Count == 0)
                {
                    Console.WriteLine("No payrolls have been recorded.\n");
                    return;
                }

                foreach (var record in records)
                {
                    Console.WriteLine(record.DisplayEmployeePay());
                }

                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError loading payroll history: {ex.Message}\n");
            }
        }
    }
}
