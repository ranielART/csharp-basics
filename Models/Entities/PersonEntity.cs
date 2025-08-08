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
        public PersonEntity(int id, string name, string email) 
        {
            this.id = id;
            this.email = email;
            this.name = name;
        }

        public int id { get;  private set; } 
        public string name { get; private set; } 

        public string email { get; private set; } 

        public abstract string DisplayInfo(); 

        public void SetName(string name) 
        {
            this.name = name;
        }

        public virtual void SetEmail(string email) 
        {
            this.email = email;
        }

    }
}
