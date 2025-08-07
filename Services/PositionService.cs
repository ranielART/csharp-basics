using csharp_basics.Interfaces;
using csharp_basics.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_basics.Services
{
    internal class PositionService
    {
        private readonly Dictionary<string, decimal> positions = new(StringComparer.OrdinalIgnoreCase)
        {
            { "Software Engineer", 50000m },
            { "Project Manager",    65000m },
            { "Intern",             15000m },
            { "HR Specialist",      40000m },
            { "Tech Lead",          80000m }
        };

        private readonly IEmployeeRepository employeeRepository;

        public PositionService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }


        public List<string> GetAllPositions()
        {
            return positions.Keys.ToList();
        }


        public decimal GetSalaryByPosition(string position)
        {
            if (positions.TryGetValue(position, out decimal salary))
            {
                return salary;
            }
            throw new ArgumentException($"Position '{position}' not found.");
        }
        public List<EmployeeEntity> GetEmployeesByPosition(string position)
        {
            return employeeRepository.GetAll()
                                     .Where(emp => emp.position.Equals(position, StringComparison.OrdinalIgnoreCase))
                                     .ToList();
        }

        public string SelectPositionFromMenu()
        {
            var positionList = GetAllPositions();

            Console.WriteLine("\nSelect Position:");
            for (int i = 0; i < positionList.Count; i++) // For loop
            {
                Console.WriteLine($"{i + 1}. {positionList[i]}");
            }

            Console.Write("Enter option number: ");
            string input = Console.ReadLine()!;
            if (!int.TryParse(input, out int selection) ||
                selection < 1 || selection > positionList.Count)
            {
                Console.WriteLine("Invalid selection. Try again.");
                return SelectPositionFromMenu();
            }

            return positionList[selection - 1];
        }
    }
}
