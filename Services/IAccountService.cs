using Data.DTOs;
using Data.Entity;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IAccountService
    {
        public AuthenticationResponse CreateAccount(UserCreation userCreation);
        public List<UserResponse> GetAcounts();

        public AuthenticationResponse GetRefreshToken();
        public User UpdateAccount(int id);
        public bool DeleteAccount(int id);
        public User GetAccountByEmail(string email);

        public AuthenticationResponse LoginAccount(AccountCredentials accountCredentials);
    }
}
