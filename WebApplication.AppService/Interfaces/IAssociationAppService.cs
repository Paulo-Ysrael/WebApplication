using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Application.ViewModel.Request;

namespace WebApplication.Application.Interfaces
{
    public interface IAssociationAppService
    {
        Task<AppServiceResponse> RegisterAssociation(AssociationRequest request);

        Task<AppServiceResponse> DeleteAssociation(AssociationRequest request);
    }
}
