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
        public string position { get; private set; }

        public EmployeeEntity(int id, string name, string email, string position) : base(id, name, email)
        {
            this.position = position;

            SetEmail(email); 
        }

        public override string DisplayInfo() 
        {
            return $"ID: {this.id} | Name: {this.name} | Email: {this.email} | Position: {this.position}"; 
        }

        public override void SetEmail(string email)
        {
            if (Regex.IsMatch(email, @"^[\w\.-]+@company\.com\.ph$")) 
            {
                base.SetEmail(email);
            }
            else
            {
                throw new ArgumentException("Email must be a valid company email ending with @company.com.ph."); 
            }
        }

        public void SetPosition(string position)
        {
            this.position = position;
        }
    }
}
