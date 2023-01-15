using Data.DataAccess;
using Data.DTOs;
using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators
{
    public class UserValidator
    {
        private readonly IAccountDAO accountDAO;
        private readonly IFamilyDAO familyDAO;

        public UserValidator(IAccountDAO accountDAO, IFamilyDAO familyDAO)
        {
            this.accountDAO = accountDAO;
            this.familyDAO = familyDAO;
        }

        public bool IsValidUser(UserCreation user)
        {
            if (user.RoleId < 0 || user.RoleId >2)
            {
                return false;
            }

            if (accountDAO.GetAccountByEmail(user.Email)!=null)
            {
                return false;
            }

            if (familyDAO.GetFamily(user.FamilyCode)==null)
            {
                return false;
            }

            return true;
        }
    }
}
