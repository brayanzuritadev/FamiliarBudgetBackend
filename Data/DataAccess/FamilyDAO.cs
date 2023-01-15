using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccess
{
    public class FamilyDAO : IFamilyDAO
    {
        private readonly ApplicationDbContext context;

        public FamilyDAO(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Family CreateFamily(Family family)
        {
            var familyEntity = context.Families.Add(family);
            context.SaveChanges();
            return familyEntity.Entity;
        }

        public Family GetFamily(string familyCode)
        {
            var familyEntity = context.Families.FirstOrDefault(x => x.FamilyCode == familyCode);
            return familyEntity;
        }
    }
}
