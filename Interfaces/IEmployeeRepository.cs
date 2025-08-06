using csharp_basics.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_basics.Interfaces
{
    internal interface IEmployeeRepository // (Interface)
    {   

        public void Add(EmployeeEntity employee);
        public List<EmployeeEntity> GetAll();

        public EmployeeEntity GetEmployeeById(int id);
        
        public void Delete(EmployeeEntity employee);
        public EmployeeEntity GetEmployeeByEmail(string email); 
    } 
}
