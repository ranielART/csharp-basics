using csharp_basics.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_basics.Interfaces
{
    internal interface IPayrollRepository
    {
        void Add(PayrollEntity payroll);
        List<PayrollEntity> GetAll();
        PayrollEntity? GetById(int id);
    }
}
