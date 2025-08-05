using csharp_basics.Interfaces;
using csharp_basics.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_basics.Repositories
{
    internal class EmployeeRepository : IEmployeeRepository
    {

        private readonly List<EmployeeEntity> employees = new List<EmployeeEntity>();
         
        public void Add(EmployeeEntity employee)
        {
            employees.Add(employee);

            
        }

        public List<EmployeeEntity> GetAll()
        { 
            return employees;
        }
    }
}
