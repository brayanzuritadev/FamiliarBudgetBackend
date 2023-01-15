using AutoMapper;
using Data.DataAccess;
using Data.DTOs;
using Data.Entity;
using Services.Utilities;
using Services.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountDAO userDAO;
        private readonly IMapper mapper;
        private readonly UserValidator userValidator;
        private readonly IFamilyDAO familyDAO;
        private readonly Hash hash;
        private readonly TokenGenerator tokenGenerator;

        public AccountService(IAccountDAO userDAO, 
            IMapper mapper, 
            UserValidator userValidator, 
            IFamilyDAO familyDAO, 
            Hash hash,
            TokenGenerator tokenGenerator)
        {
            this.userDAO = userDAO;
            this.mapper = mapper;
            this.userValidator = userValidator;
            this.familyDAO = familyDAO;
            this.hash = hash;
            this.tokenGenerator = tokenGenerator;
        }
        public AuthenticationResponse CreateAccount(UserCreation userCreation)
        {
            var family = familyDAO.GetFamily(userCreation.FamilyCode);
            var user = mapper.Map<User>(userCreation);
   
            if (family==null || userValidator.IsValidUser(userCreation)==false)
            {
                return null;
            }

            user.FamilyId = family.Id;
            user.Password = hash.HashPassword(userCreation.Password);

            var userEntity = userDAO.CreateAccount(user);

            var token = tokenGenerator.BuildToken(userEntity);

            return token;
        }

        public bool DeleteAccount(int id)
        {
            throw new NotImplementedException();
        }

        public User GetAccountByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAcounts(string familyCode)
        {
            throw new NotImplementedException();
        }

        public AuthenticationResponse LoginAccount(AccountCredentials accountCredentials)
        {
            var user = userDAO.GetAccountByEmail(accountCredentials.Email);
            if(user!=null&& hash.HashPassword(accountCredentials.Password) == user.Password)
            {
                return tokenGenerator.BuildToken(user);
            }
            return null;
        }

        public User UpdateAccount(int id)
        {
            throw new NotImplementedException();
        }
    }
}
