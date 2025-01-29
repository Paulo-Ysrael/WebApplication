using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Domain.Entity;
using WebApplication.Domain.Interfaces;
using WebApplication.Domain.InterfacesRepository;

namespace WebApplication.Domain.Services
{
    public class AssociationService : IAssociationService
    {
        private readonly IAssociationRepository _associationRepository;

        public AssociationService(IAssociationRepository associationRepository)
        {
            _associationRepository = associationRepository;
        }

        public async Task<Association> GetAssociation(int membersId, int companyId)
        {
            return await _associationRepository.GetAssociation(membersId, companyId);
        }

        public async Task RegisterAssociation(Association association)
        {
            await _associationRepository.RegisterAssociation(association);
        }

        public async Task DeleteAssociation(Association association)
        {
            await _associationRepository.DeleteAssociation(association);
        }
    }
}
