using csharp_basics.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_basics.Interfaces
{
    internal interface IEmployeeRepository
    {
        public Task Add(EmployeeEntity employee);
        public Task<List<EmployeeEntity>> GetAll();
    }
}
