using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Application.ViewModel.Response
{
    public class CompanyResponse
    {
        public long Identifier { get; set; }

        public string Name { get; set; }

        public string CNPJ { get; set; }
    }
}
