using System;

namespace csharp_basics.Models.Entities
{
    internal class PayrollEntity
    {
        public int id { get; private set; }
        public int employee_id { get; private set; }
        public string employee_name { get; private set; }
        public string position { get; private set; }
        public decimal amount_paid { get; private set; }
        public DateTime date_paid { get; private set; }

        public PayrollEntity(int id, int employee_id, string employee_name, string position, decimal amount_paid)
        {
            this.id = id;
            this.employee_id = employee_id;
            this.employee_name = employee_name;
            this.position = position;
            this.amount_paid = amount_paid;
            this.date_paid = DateTime.Now;
        }
        
        public string DisplayEmployeePay()
        {
            return $"Payroll ID: {id} | Employee: {employee_name} (ID: {employee_id}) | " +
                   $"Position: {position} | Amount: PHP {amount_paid:N2} | Date: {date_paid}";
        }
    }
}
