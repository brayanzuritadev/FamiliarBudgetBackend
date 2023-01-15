using Data.DTOs;
using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IFamilyService
    {
        public Family CreateFamily(FamilyCreation familyCreation);
        public Family GetFamily(string family);
    }
}
