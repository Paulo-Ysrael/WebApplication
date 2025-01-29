using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Domain.Entity
{
    public class Company
    {
        public int Identifier { get; set; }

        public string Name { get; set; }

        public string CNPJ { get; set; }

        public virtual ICollection<Association> Association { get; set; }

        public static Company Create(string name, string cnpj)
        {
            return new Company
            {
                Name = name,
                CNPJ = cnpj
            };
        }
    }
}
