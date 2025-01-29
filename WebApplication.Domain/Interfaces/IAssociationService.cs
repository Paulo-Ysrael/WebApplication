using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Domain.Entity;

namespace WebApplication.Domain.Interfaces
{
    public interface IAssociationService
    {
        Task<Association> GetAssociation(int membersId, int companyId);

        Task RegisterAssociation(Association association);

        Task DeleteAssociation(Association association);
    }
}
