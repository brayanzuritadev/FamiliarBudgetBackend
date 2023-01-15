using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccess
{
    public interface IFamilyDAO
    {
        public Family CreateFamily(Family family);
        public Family GetFamily(string familyCode);
    }
}
