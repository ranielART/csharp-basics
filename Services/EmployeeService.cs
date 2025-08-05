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

        public async Task addEmployeeAsync(EmployeeEntity employee)
        {
            await employeeRepository.Add(employee);
        }

        public async Task<List<EmployeeEntity>> GetAllEmployeesAsync()
        {
            return await employeeRepository.GetAll();
        }


    }
}
