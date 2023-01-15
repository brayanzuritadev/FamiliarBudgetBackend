using AutoMapper;
using Data.DataAccess;
using Data.DTOs;
using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class FamilyService : IFamilyService
    {
        private readonly IFamilyDAO familyDAO;
        private readonly IMapper mapper;

        public FamilyService(IFamilyDAO familyDAO, IMapper mapper)
        {
            this.familyDAO = familyDAO;
            this.mapper = mapper;
        }
        public Family CreateFamily(FamilyCreation familyCreation)
        {
            var family = mapper.Map<Family>(familyCreation);
            family.FamilyCode = Guid.NewGuid().ToString();

            return familyDAO.CreateFamily(family);
        }

        public Family GetFamily(string familyCode)
        {
            return familyDAO.GetFamily(familyCode);
        }
    }
}
