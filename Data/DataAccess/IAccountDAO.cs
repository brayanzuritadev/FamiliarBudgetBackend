using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccess
{
    public interface IAccountDAO
    {
        public User CreateAccount(User user);
        public List<User> GetAccounts(int familyCodeId);
        public User GetAccountByEmail(string email);
    }
}
