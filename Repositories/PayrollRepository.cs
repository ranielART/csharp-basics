using csharp_basics.Interfaces;
using csharp_basics.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_basics.Repositories
{
    internal class PayrollRepository : IPayrollRepository
    {

        private readonly List<PayrollEntity> payrolls = new List<PayrollEntity>();
        private int currentId = 1;

        public void Add(PayrollEntity payroll)
        {
            payrolls.Add(payroll);
            currentId++;
        }

        public List<PayrollEntity> GetAll()
        {
            return payrolls;
        }

        public PayrollEntity? GetById(int id)
        {
            return payrolls.FirstOrDefault(p => p.id == id);
        }

        public int GenerateNextId()
        {
            return currentId;
        }

    }
}
