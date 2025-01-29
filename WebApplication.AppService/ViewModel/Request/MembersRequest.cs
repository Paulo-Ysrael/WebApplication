using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Application.ViewModel.Request
{
    public class MembersRequest
    {
        public int? Identifier { get; set; }

        public string Name { get; set; }

        public string CPF { get; set; }

        public string Birth { get; set; }
    }
}
