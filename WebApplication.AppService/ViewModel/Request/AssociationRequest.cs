using System.ComponentModel.DataAnnotations;

namespace WebApplication.Application.ViewModel.Request
{
    public class AssociationRequest
    {
        [Required()]
        public int MembersId { get; set; }

        [Required()]
        public int CompanyId { get; set; }
    }
}
