using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccess
{
    public class AccountDAO : IAccountDAO
    {
        private readonly ApplicationDbContext context;

        public AccountDAO(ApplicationDbContext context)
        {
            this.context = context;
        }
        public User CreateAccount(User user)
        {
            var userEntity = context.Users.Add(user);
            context.SaveChanges();

            return userEntity.Entity;
        }

        public List<User> GetAccounts(int familyCodeId)
        {
            var Users = context.Users.Where(x => x.FamilyId == familyCodeId).ToList();
            return Users;
        }

        public User GetAccountByEmail(string email)
        {
            var userEntity = context.Users.FirstOrDefault(x => x.Email == email);

            return userEntity;
        }
    }
}
