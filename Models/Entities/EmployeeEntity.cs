using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace csharp_basics.Models.Entities
{
    internal class EmployeeEntity : PersonEntity
    {

        public string department { get; private set; }

        public EmployeeEntity(int id, string name, string email, string department) : base(id, name, "")
        {
            this.department = department;
            SetEmail(email); // Ensure email is set through the method to validate it
        }



        public override string DisplayInfo() // (Method Overriding)
        {
            return $"ID: {this.id}, Name: {this.name}, Email: {this.email}, Department: {this.department}"; // String interpolation for displaying employee details
        }

        public override void SetEmail(string email)
        {
            if (Regex.IsMatch(email, @"^[\w\.-]+@company\.com\.ph$")) // (Regex) Validate email ends with @company.com.ph
            {
                base.SetEmail(email);
            }
            else
            {
                throw new ArgumentException("Email must be a valid company email ending with @company.com.ph"); // Throwing a custom exception if email validation fails
            }
        }

        public void SetDepartment(string department)
        {
            this.department = department;
        }

    }
}
