using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Application.ViewModel.Response
{
    public class MembersResponse
    {
        public int Identifier { get; set; }

        public string Name { get; set; }

        public string CPF { get; set; }

        public DateTime Birth { get; set; }
    }
}
