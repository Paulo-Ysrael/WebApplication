using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Domain.Entity
{
    public class Association
    {
        public int Identifier { get; set; }

        public int MembersId { get; set; }
        public Members Members { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public static Association Create(int membersId, int companyId)
        {
            return new Association
            {
                MembersId = membersId,
                CompanyId = companyId
            };
        }
    }
}
