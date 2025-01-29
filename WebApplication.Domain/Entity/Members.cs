using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Domain.Entity
{
    public class Members
    {
        public int Identifier { get; set; }

        public string Name { get; set; }

        public string CPF { get; set; }

        public DateTime Birth { get; set; }

        public virtual ICollection<Association> Association { get; set; }

        public static Members Create(string name, string cpf, string birth)
        {
            return new Members
            {
                Name = name,
                CPF = cpf, 
                Birth = DateTime.Parse(birth)
            };
        }
    }
}
