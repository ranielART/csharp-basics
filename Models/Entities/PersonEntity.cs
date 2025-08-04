using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace csharp_basics.Models.Entities
{
    internal abstract class PersonEntity
    {

        public PersonEntity(int id, string name, string email) // (Constructor) Initializes a new instance of the PersonEntity class with id, name, and email
        {
            this.id = id;
            this.email = email;
            this.name = name;
        }

        public int id { get;  private set; } // (Encapsulation)
        public string name { get; private set; } // (Encapsulation) Properties with private setters to restrict modification

        public string email { get; private set; } // (Encapsulation)

        public abstract string DisplayInfo(); // (Abstraction) Abstract method to be implemented by derived classes for displaying person details

        public void SetName(string name) 
        {
            this.name = name;
        }

        public virtual void SetEmail(string email) // (Polymorphism)
        {
            this.email = email;
        }

    }
}
