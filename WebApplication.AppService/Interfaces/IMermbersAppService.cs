using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Application.ViewModel.Request;
using WebApplication.Application.ViewModel.Response;

namespace WebApplication.Application.Interfaces
{
    public interface IMermbersAppService
    {
        Task<AppServiceResponse> GetList();

        Task<AppServiceResponse> GetMembers(int identifier);

        Task<AppServiceResponse> GetMembersByName(string name);

        Task<AppServiceResponse> GetMembersByCpf(string cpf);

        Task<AppServiceResponse> RegisterMember(MembersRequest request);

        Task<AppServiceResponse> Update(MembersRequest request);
    }
}
